using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// �������������� �������
    /// </summary>
    public static class TMath
        {
        /// <summary>
        /// ���������� � ���������� ������ �����
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>����� �����</returns>
        public static int Round( double value )
            {
            return (int)Math.Round( value, MidpointRounding.ToEven );
            }


        /// <summary>
        /// �����
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Sin( double value )
            {
            return Math.Sin( value );
            }


        /// <summary>
        /// �������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Cos( double value )
            {
            return Math.Cos( value );
            }


        /// <summary>
        /// �������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Tan( double value )
            {
            return Math.Tan( value );
            }


        /// <summary>
        /// ���� �����
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>-1 | 0 | 1</returns>
        public static int Sign( double value )
            {
            return Math.Sign( value );
            }


        /// <summary>
        /// ������ �����
        /// </summary>
        /// <param name="value">����� �����</param>
        /// <returns>����� �����</returns>
        public static int Abs( int value )
            {
            return Math.Abs( value );
            }


        /// <summary>
        /// ������ �����
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double AbsReal( double value )
            {
            return Math.Abs( value );
            }


        /// <summary>
        /// ����������� ��������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Ln( double value )
            {
            return Math.Log( value );
            }


        /// <summary>
        /// ���������� ��������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Log( double value )
            {
            return Math.Log10( value );
            }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Asin( double value )
            {
            return Math.Asin( value );
            }


        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Acos( double value )
            {
            return Math.Acos( value );
            }


        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Atan( double value )
            {
            return Math.Atan( value );
            }


        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Exp( double value )
            {
            return Math.Exp( value );
            }


        /// <summary>
        /// ���������� � �������
        /// </summary>
        /// <param name="x">������������ �����</param>
        /// <param name="y">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Pow( double x, double y )
            {
            return Math.Pow( x, y );
            }


        /// <summary>
        /// ���������� ������
        /// </summary>
        /// <param name="value">������������ �����</param>
        /// <returns>������������ �����</returns>
        public static double Sqrt( double value )
            {
            return Math.Sqrt( value );
            }

        }
    }
