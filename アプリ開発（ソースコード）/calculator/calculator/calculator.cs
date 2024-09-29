using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace calculator
{

    public partial class calculator : Form
    {
        //計算結果
        String answer = "0";

        //演算子
        String prevOperator = null;

        //小数点ボタンフラグ
        Boolean decimalPointFlug = false;

        //演算子フラグ
        Boolean operatorFlug = false;

        //計算用
        decimal calcFirstNum = 0;
        decimal calcSecondNum = 0;


        public calculator()
        {
            InitializeComponent();
            btnEqual.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //引数の数値の整数部の桁数を返すメソッド
        private int integerDigit(decimal answer)
        {
            string strAnswer = answer.ToString();
            int index = strAnswer.IndexOf('.');
            if (index == -1)
                return 0;

            return strAnswer.Substring(0, index).Length;
        }

        //引数の数値の小数点以下の桁数(末尾の0も含む)を返すメソッド
        private int decimalDigit(decimal answer)
        {
            string strAnswer = answer.ToString();
            int index = strAnswer.IndexOf('.');
            if (index == -1)
                return 0;

            return strAnswer.Substring(index + 1).Length;
        }

        //数字ボタン(0～9)押下時の処理
        private void concatNum(String btnNum)
        {
            if (answer == "0")
            {
                //「押下した数字ボタンの値」で上書きする。
                answer = btnNum;
            }
            else
            {
                //計算結果表示欄に表示されている値に、「押下した数字ボタンの値」を結合する。
                answer = answer + btnNum;
            }

            //計算結果表示欄の数値の桁数チェック
            if (Regex.Matches(answer, @"[0-9]").Count <= 12)
            {
                //計算結果表示欄に、値を設定する。
                if (answer.Contains("."))
                {
                    //小数点以下の桁数を取得
                    int digit = decimalDigit(decimal.Parse(answer));
                    //カンマと小数点の共存
                    calculationResult.Text = decimal.Parse(answer).ToString("N" + digit);
                }
                else
                {
                    calculationResult.Text = decimal.Parse(answer).ToString("N0");
                }
            }
            else
            {
                //計算結果表示欄に表示されている値が最大桁数を超えたらエラー
                textError.Text = "E";
                buttonEnabled(false);
            }


            //演算子フラグをtrueにする。（演算子ボタンを連続して押下した際に、何も処理を起こさないようにする）
            if (operatorFlug == false)
            {
                operatorFlug = true;
            }

        }



        private void btn1_Click(object sender, EventArgs e)
        {
            concatNum("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            concatNum("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            concatNum("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            concatNum("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            concatNum("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            concatNum("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            concatNum("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            concatNum("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            concatNum("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            concatNum("0");
        }

        //ACボタンの処理
        private void btnAllClear_Click(object sender, EventArgs e)
        {
            prevOperator = null;
            answer = "0";
            calculationResult.Text = answer;
            calculationProcess.Text = null;
            calcFirstNum = 0;
            calcSecondNum = 0;
            operatorFlug = false;
            textError.Text = null;
            buttonEnabled(true);
        }

        //Cボタンの処理
        private void btnClear_Click(object sender, EventArgs e)
        {
            answer = "0";
            calculationResult.Text = answer;
        }

        //演算系ボタン（+,-,*,/,=）の処理
        private void calculation(String clacOperator)
        {

            //事前に演算系ボタンを押下しているかどうかを判定
            if (prevOperator != null)
            {
                //検索結果表示欄の値をセットする
                calcSecondNum = decimal.Parse(calculationResult.Text);
                //各演算子毎の計算
                if (prevOperator.Equals("+"))
                {
                    answer = (calcFirstNum + calcSecondNum).ToString();
                }
                else if (prevOperator.Equals("-"))
                {
                    answer = (calcFirstNum - calcSecondNum).ToString();
                }
                else if (prevOperator.Equals("×"))
                {
                    answer = (calcFirstNum * calcSecondNum).ToString();
                }
                else if (prevOperator.Equals("÷"))
                {
                    try
                    {
                        answer = (calcFirstNum / calcSecondNum).ToString();
                    }
                    catch (DivideByZeroException e)
                    {
                        //0除算した際の処理
                        textError.Text = "E";
                        buttonEnabled(false);
                        return;
                    }
                }

                //計算結果の桁数チェック(除算の場合、割る数が1より大きければ最大桁数を超えることはない)
                if (Regex.Matches(answer, @"[0-9]").Count <= 12 || (prevOperator.Equals("÷") && calcSecondNum >= 1))
                {
                    //計算結果が少数かどうかを判定し、計算結果を計算結果表示欄に表示。
                    if (answer.Contains("."))
                    {
                        //除算で最大桁数を超えた場合、最大桁数に合わせる
                        if (prevOperator.Equals("÷"))
                        {
                            //整数部の桁数を取得
                            int digit = integerDigit(decimal.Parse(answer));
                            calculationResult.Text = decimal.Parse(answer).ToString("N" + (12 - digit));
                        }
                        else
                        {
                            calculationResult.Text = decimal.Parse(answer).ToString("N12").TrimEnd('0');
                        }
                    }
                    else
                    {
                        calculationResult.Text = decimal.Parse(answer).ToString("N0");
                    }
                    //計算結果表示欄の値を、計算過程表示欄に表示。
                    calculationProcess.Text = calculationResult.Text;

                    //等号ボタン以外の場合
                    if (clacOperator.Equals("=") == false)
                    {
                        //計算過程表示欄に演算子を追加。
                        calculationProcess.Text += clacOperator;
                    }
                }
                else
                {
                    //計算結果が最大桁数を超えたらエラー
                    textError.Text = "E";
                    buttonEnabled(false);
                }
            }
            else
            {
                //計算結果表示欄の値を、計算過程表示欄に追加する。
                calculationProcess.Text = calculationResult.Text;
                //計算過程表示欄に演算子を追加。
                calculationProcess.Text += clacOperator;

            }

            //等号ボタンの処理
            if (clacOperator.Equals("="))
            {
                //演算子の値を消去する
                prevOperator = null;
            }
            else
            {
                btnEqual.Enabled = true;
                //演算子フラグをfalseにする。
                operatorFlug = false;
                //演算子の値を格納する。
                prevOperator = clacOperator;
            }

            //演算結果を、次回の演算に使用するために変数に格納
            calcFirstNum = decimal.Parse(calculationResult.Text);
            answer = "0";
            //小数点ボタンフラグをfalseにする
            decimalPointFlug = false;
        }

        private void btnWaru_Click(object sender, EventArgs e)
        {
            if (operatorFlug == true)
            {
                calculation("÷");
            }

        }

        private void btnKakeru_Click(object sender, EventArgs e)
        {
            if (operatorFlug == true)
            {
                calculation("×");
            }

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (operatorFlug == true)
            {
                calculation("-");
            }

        }
        //加算ボタンの処理
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (operatorFlug == true)
            {
                calculation("+");
            }

        }
        //等号ボタンの処理
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (operatorFlug == true)
            {
                calculation("=");
                btnEqual.Enabled = false;
            }
        }
        //小数点ボタンの処理
        private void btnPoint_Click(object sender, EventArgs e)
        {
            //小数点ボタンが事前に押されているかを判定
            if (decimalPointFlug == false)
            {
                answer = decimal.Parse(answer).ToString("N0") + ".";
                calculationResult.Text = answer;
                decimalPointFlug = true;
            }
        }

        //エラー後、AC,Cボタン以外使用不可
        private void buttonEnabled(Boolean con)
        {
            btn1.Enabled = con;
            btn2.Enabled = con;
            btn3.Enabled = con;
            btn4.Enabled = con;
            btn5.Enabled = con;
            btn6.Enabled = con;
            btn7.Enabled = con;
            btn8.Enabled = con;
            btn9.Enabled = con;
            btn0.Enabled = con;
            btnWaru.Enabled = con;
            btnKakeru.Enabled = con;
            btnMinus.Enabled = con;
            btnPlus.Enabled = con;
            btnEqual.Enabled = con;
            btnPoint.Enabled = con;
            btnClear.Enabled = con;
        }
    }
}
