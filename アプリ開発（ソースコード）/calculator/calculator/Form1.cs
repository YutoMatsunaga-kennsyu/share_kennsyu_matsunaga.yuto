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

namespace calculator
{
    public partial class Form1 : Form
    {
        String answer = "0";
        String prevOperator = null;
        //小数点ボタンフラグ
        Boolean decimalPointFlug = false;
        //演算子フラグ
        Boolean operatorFlug = false;

        decimal calcFirstNum = 0;
        decimal calcSecondNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //数字ボタン(0～9)押下時の処理
        private void concatNum(String btnNum)
        {
            if (answer == "0")
            {
                //計算結果表示欄の値が「0」の時、「押下した数字ボタンの値」で上書きする。
                answer = btnNum;
            }
            else
            {
                //計算結果表示欄の値が「0」以外の時、計算結果表示欄に表示されている値に、「押下した数字ボタンの値」を結合する。
                answer = answer + btnNum;
            }

            //計算結果表示欄のTextプロパティに、値を設定する。
            calculationResult.Text = answer;
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

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            //演算子をnullにする
            prevOperator = null;
            answer = "0";
            calculationResult.Text = answer;
            calcFirstNum = 0;
            calcSecondNum = 0;
            operatorFlug = false;
        }

        //クリアボタン押下時の処理
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
                    calculationResult.Text = (calcFirstNum + calcSecondNum).ToString();
                }
                else if (prevOperator.Equals("-"))
                {
                    calculationResult.Text = (calcFirstNum - calcSecondNum).ToString();
                }
                else if (prevOperator.Equals("*"))
                {
                    calculationResult.Text = (calcFirstNum * calcSecondNum).ToString();
                }
                else if (prevOperator.Equals("/"))
                {
                    try
                    {
                        calculationResult.Text = (calcFirstNum / calcSecondNum).ToString();
                    }
                    catch (DivideByZeroException e)
                    {
                        //0除算した際の処理
                        calculationResult.Text = "Error";
                        answer = "0";
                        return;
                    }
                }
            }

            //等号ボタン以外の処理
            if (clacOperator.Equals("="))
            {
                //演算子の値を消去する
                prevOperator = null;
            }
            else
            {
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
                calculation("/");
            }

        }

        private void btnKakeru_Click(object sender, EventArgs e)
        {
            if (operatorFlug == true)
            {
                calculation("*");
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
            }
        }
        //小数点ボタンの処理
        private void btnPoint_Click(object sender, EventArgs e)
        {
            //計算結果表示欄の数値が小数点ボタンを押下されることで、少数になったかどうかを判定
            if (decimalPointFlug == false)
            {
                answer = answer + ".";
                calculationResult.Text = answer;
                decimalPointFlug = true;
            }
        }
    }
}
