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
    ///<summary>電卓アプリの処理</summary>
    public partial class Calculator : Form
    {
        //計算結果
        String gStrAnswer = "0";

        //演算子
        String strPrevOperator = null;

        //小数点ボタンフラグ
        Boolean decimalPointFlag = false;

        //演算子フラグ
        Boolean operatorFlag = false;

        //計算用数値
        decimal decCalcFirstNum = 0;
        decimal decCalcSecondNum = 0;

        /// <summary>電卓アプリ起動時の処理</summary>
        public Calculator()
        {
            InitializeComponent();
            btnEqual.Enabled = false;
        }

        /// <summary>数値から整数部の桁数を取得する</summary>
        /// <param decAnswer="decAnswer">整数部の桁数を取得したい数値</param>
        /// <returns>引数の数値の整数部の桁数</returns>
        private int GetIntegerDigit(decimal decAnswer)
        {
            string _strAnswer = decAnswer.ToString();
            int numIndex = _strAnswer.IndexOf('.');
            if (numIndex == -1)
            {
                return 0;
            }
            return _strAnswer.Substring(0, numIndex).Length;
        }

        /// <summary>数値から小数点以下の桁数を取得する</summary>
        /// <param decAnswer="decAnswer">小数点以下の桁数を取得したい数値</param>
        /// <returns>引数の数値の小数点以下の桁数</returns>
        private int GetDecimalDigit(decimal decAnswer)
        {
            string _strAnswer = decAnswer.ToString();
            int numIndex = _strAnswer.IndexOf('.');
            if (numIndex == -1)
            {
                return 0;
            }
            return _strAnswer.Substring(numIndex + 1).Length;
        }

        /// <summary>数字ボタン(0～9)押下時の処理</summary>
        /// <param strBtnNum="strBtnNum">押下した数字ボタンの数値</param>
        private void ConcatNum(String strBtnNum)
        {
            if (gStrAnswer == "0")
            {
                //「押下した数字ボタンの値」で上書きする。
                gStrAnswer = strBtnNum;
            }
            else
            {
                //計算結果表示欄に表示されている値に、「押下した数字ボタンの値」を結合する。
                gStrAnswer = gStrAnswer + strBtnNum;
            }

            //計算結果表示欄の数値の桁数チェック
            if (Regex.Matches(gStrAnswer, @"[0-9]").Count <= 12)
            {
                //計算結果表示欄に、値を設定する。
                if (gStrAnswer.Contains("."))
                {
                    //小数点以下の桁数を取得
                    int numDigit = GetDecimalDigit(decimal.Parse(gStrAnswer));
                    //カンマと小数点の共存
                    calculationResult.Text = decimal.Parse(gStrAnswer).ToString("N" + numDigit);
                }
                else
                {
                    calculationResult.Text = decimal.Parse(gStrAnswer).ToString("N0");
                }
            }
            else
            {
                //計算結果表示欄に表示されている値が最大桁数を超えたらエラー
                textError.Text = "E";
                BtnEnabled(false);
            }

            //演算子フラグをtrueにする。（演算子ボタンを連続して押下した際に、何も処理を起こさないようにする）
            if (operatorFlag == false)
            {
                operatorFlag = true;
            }
        }

        /// <summary>数字ボタン(1)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn1_Click(object sender, EventArgs e)
        {
            ConcatNum("1");
        }

        /// <summary>数字ボタン(2)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn2_Click(object sender, EventArgs e)
        {
            ConcatNum("2");
        }

        /// <summary>数字ボタン(3)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn3_Click(object sender, EventArgs e)
        {
            ConcatNum("3");
        }

        /// <summary>数字ボタン(4)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn4_Click(object sender, EventArgs e)
        {
            ConcatNum("4");
        }

        /// <summary>数字ボタン(5)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn5_Click(object sender, EventArgs e)
        {
            ConcatNum("5");
        }

        /// <summary>数字ボタン(6)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn6_Click(object sender, EventArgs e)
        {
            ConcatNum("6");
        }

        /// <summary>数字ボタン(7)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn7_Click(object sender, EventArgs e)
        {
            ConcatNum("7");
        }

        /// <summary>数字ボタン(8)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn8_Click(object sender, EventArgs e)
        {
            ConcatNum("8");
        }

        /// <summary>数字ボタン(9)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn9_Click(object sender, EventArgs e)
        {
            ConcatNum("9");
        }

        /// <summary>数字ボタン(0)押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void Btn0_Click(object sender, EventArgs e)
        {
            ConcatNum("0");
        }

        /// <summary>ACボタン押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void BtnAllClear_Click(object sender, EventArgs e)
        {
            strPrevOperator = null;
            gStrAnswer = "0";
            calculationResult.Text = gStrAnswer;
            calculationProcess.Text = null;
            decCalcFirstNum = 0;
            decCalcSecondNum = 0;
            operatorFlag = false;
            decimalPointFlag = false;
            textError.Text = null;
            BtnEnabled(true);
        }

        /// <summary>Cボタン押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            decimalPointFlag = false;
            gStrAnswer = "0";
            calculationResult.Text = gStrAnswer;
        }

        /// <summary>演算系（+,-,*,/,=）ボタン押下時の処理</summary>
        /// <param strCalcOperator="strCalcOperator">直前に押下した演算子ボタンの演算子の値</param>
        private void Calculation(String strCalcOperator)
        {
            //事前に演算系ボタンを押下しているかどうかを判定
            if (strPrevOperator != null)
            {
                //検索結果表示欄の値をセットする
                decCalcSecondNum = decimal.Parse(calculationResult.Text);
                //各演算子毎の計算
                if (strPrevOperator.Equals("+"))
                {
                    gStrAnswer = (decCalcFirstNum + decCalcSecondNum).ToString();
                }
                else if (strPrevOperator.Equals("-"))
                {
                    gStrAnswer = (decCalcFirstNum - decCalcSecondNum).ToString();
                }
                else if (strPrevOperator.Equals("×"))
                {
                    gStrAnswer = (decCalcFirstNum * decCalcSecondNum).ToString();
                }
                else if (strPrevOperator.Equals("÷"))
                {
                    try
                    {
                        gStrAnswer = (decCalcFirstNum / decCalcSecondNum).ToString();
                    }
                    catch (DivideByZeroException e)
                    {
                        //0除算した際の処理
                        textError.Text = "E";
                        BtnEnabled(false);
                        return;
                    }
                }

                //計算結果の桁数チェック(除算の場合、割る数が1より大きければ最大桁数を超えることはない)
                if (Regex.Matches(gStrAnswer, @"[0-9]").Count <= 12 || (strPrevOperator.Equals("÷") && decCalcSecondNum >= 1))
                {
                    //計算結果が少数かどうかを判定し、計算結果を計算結果表示欄に表示。
                    if (gStrAnswer.Contains(".") && decimal.Parse(gStrAnswer) % 1 != 0)
                    {
                        //除算で最大桁数を超えた場合、最大桁数に合わせる
                        if (strPrevOperator.Equals("÷"))
                        {
                            //整数部の桁数を取得
                            int numDigit = GetIntegerDigit(decimal.Parse(gStrAnswer));
                            calculationResult.Text = decimal.Parse(gStrAnswer).ToString("N" + (12 - numDigit)).TrimEnd('0');
                        }
                        else
                        {
                                calculationResult.Text = decimal.Parse(gStrAnswer).ToString("N12").TrimEnd('0');
                        }
                    }
                    else
                    {
                        calculationResult.Text = decimal.Parse(gStrAnswer).ToString("N0");
                    }
                    //計算結果表示欄の値を、計算過程表示欄に表示。
                    calculationProcess.Text = calculationResult.Text;

                    //等号ボタン以外の場合
                    if (strCalcOperator.Equals("=") == false)
                    {
                        //計算過程表示欄に演算子を追加。
                        calculationProcess.Text += strCalcOperator;
                    }
                }
                else
                {
                    //計算結果が最大桁数を超えたらエラー
                    textError.Text = "E";
                    BtnEnabled(false);
                }
            }
            else
            {
                //計算結果表示欄の値を、計算過程表示欄に追加する。
                calculationProcess.Text = calculationResult.Text;
                //計算過程表示欄に演算子を追加。
                calculationProcess.Text += strCalcOperator;
            }

            //等号ボタンの処理
            if (strCalcOperator.Equals("="))
            {
                //演算子の値を消去する
                strPrevOperator = null;
            }
            else
            {
                btnEqual.Enabled = true;
                //演算子フラグをfalseにする。
                operatorFlag = false;
                //演算子の値を格納する。
                strPrevOperator = strCalcOperator;
            }
            //演算結果を、次回の演算に使用するために変数に格納
            decCalcFirstNum = decimal.Parse(calculationResult.Text);
            gStrAnswer = "0";
            //小数点ボタンフラグをfalseにする
            decimalPointFlag = false;
        }

        /// <summary>除算ボタン押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void BtnWaru_Click(object sender, EventArgs e)
        {
            if (operatorFlag == true)
            {
                Calculation("÷");
            }
        }

        /// <summary>乗算ボタン押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void BtnKakeru_Click(object sender, EventArgs e)
        {
            if (operatorFlag == true)
            {
                Calculation("×");
            }
        }

        /// <summary>減算ボタン押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            if (operatorFlag == true)
            {
                Calculation("-");
            }
        }

        /// <summary>加算ボタン押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void BtnPlus_Click(object sender, EventArgs e)
        {
            if (operatorFlag == true)
            {
                Calculation("+");
            }
        }

        /// <summary>等号ボタン押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void BtnEqual_Click(object sender, EventArgs e)
        {
            if (operatorFlag == true)
            {
                Calculation("=");
                btnEqual.Enabled = false;
            }
        }

        /// <summary>小数点ボタン押下時の処理</summary>
        /// <param sender="sender">イベントを発生させるインスタンスへの参照</param>
        /// <param e="e">イベントのインスタンス</param>
        private void BtnPoint_Click(object sender, EventArgs e)
        {
            //小数点ボタンが事前に押されているかを判定
            if (decimalPointFlag == false)
            {
                gStrAnswer = decimal.Parse(gStrAnswer).ToString("N0") + ".";
                calculationResult.Text = gStrAnswer;
                decimalPointFlag = true;
            }
        }

        /// <summary>ACボタン以外のボタンを制御する</summary>
        /// <param con="con">ボタンを使用可能にする際は「true」、使用不可は「false」</param>
        private void BtnEnabled(Boolean con)
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