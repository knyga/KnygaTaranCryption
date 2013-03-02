using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace KnygaTaranCryptoLib
{
    /// <summary>
    /// Позволяет удобно управлять битовыми/байтовыми данными
    /// </summary>
    public class Data100
    {
        byte[] _data = new byte[0];
        Encoding _encoding = Encoding.Default;

        /// <summary>
        /// Массив битов входных данных
        /// </summary>
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// Кодировка
        /// </summary>
        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        #region data
        private List<BOMIndentifer> bomList = new List<BOMIndentifer>(){
            new BOMIndentifer(){Encoding = Encoding.UTF8,
                Identifers = new byte[][] {
                    new byte[] {239, 187, 191}
                }
            },
            new BOMIndentifer(){Encoding = Encoding.Unicode,
                Identifers = new byte[][] {
                    new byte[] {254, 255}, //UTF-16 (BE)
                    new byte[] {255, 254} //UTF-16 (LE)
                }
            },
            new BOMIndentifer(){Encoding = Encoding.UTF32,
                Identifers = new byte[][] {
                    new byte[] {0, 0, 254, 255}, //UTF-32 (BE)
                    new byte[] {255, 254, 0, 0} //UTF-32 (LE)
                }
            },
            new BOMIndentifer(){Encoding = Encoding.UTF7,
                Identifers = new byte[][] {
                    new byte[] {43, 47, 118, 56},
                    new byte[] {43, 47, 118, 57},
                    new byte[] {43, 47, 118, 43},
                    new byte[] {43, 47, 118, 47}
                }
            }
        };
        /// <summary>
        /// BOM-идентификаторы страниц
        /// </summary>
        public List<BOMIndentifer> BomList
        {
            get { return bomList; }
            set { bomList = value; }
        }
        #endregion

        #region constructors
        public Data100(byte[] data)
        {
            this._data = data;
        }

        public Data100(string text, Encoding encoding)
        {
            ReadFromText(text, encoding);
        }

        public Data100(string text)
            : this(text, Encoding.Default)
        {
        }

        public Data100()
            : this(string.Empty, Encoding.Default)
        {
        }
        #endregion

        #region cropers
        /// <summary>
        /// Сократить длину данный с from байта до to байта
        /// </summary>
        /// <param name="from">Номер первого байта</param>
        /// <param name="to">Номер последнего байта</param>
        public void Crop(int from, int to)
        {
            int length = to - from;
            byte[] ba = new byte[length];
            for (int i = 0; i < length; i++)
            {
                ba[i] = _data[from + i];
            }
            _data = ba;
        }

        /// <summary>
        /// Сократить длину данных
        /// </summary>
        /// <param name="length">Длина новых данных</param>
        public void Crop(int length)
        {
            Crop(0, length);
        }

        /// <summary>
        /// Убирает BOM идентификаторы, если находит
        /// </summary>
        public void EscapeBOM()
        {
            BOMIndentifer bi = bomList.Find(x => x.Encoding.EncodingName == _encoding.EncodingName);
            if (bi != null && _data.Length>=bi.Identifers[0].Length)
            {
                bool matched = true;
                for (int i = 0; i < bi.Identifers.Length; i++)
                {
                    matched = true;

                    for (int j = 0; j < bi.Identifers[i].Length; j++)
                    {
                        if (bi.Identifers[i][j] != _data[j])
                        {
                            matched = false;
                            break;
                        }
                    }
                }
                if (matched)
                    Crop(bi.Identifers[0].Length, _data.Length);
            }
        }
        #endregion

        #region readers
        /// <summary>
        /// Прочитать из строки, преобразуя каждый символ в True или False
        /// </summary>
        /// <param name="text">Текст</param>
        public void ReadFromBooleanText(string text)
        {
            BitArray bt = new BitArray(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                bt[i] = text[i] == '1';
            }
            _data = ToByteArray(bt);
        }

        /// <summary>
        /// Прочитать из строки с учетом кодировка
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="encoding">Кодировка</param>
        public void ReadFromText(string text, Encoding encoding)
        {
            this._encoding = encoding;
            this._data = encoding.GetBytes(text);
        }

        /// <summary>
        /// Прочитать из строки с учетом кодировка
        /// </summary>
        /// <param name="text">Текст</param>
        public void ReadFromText(string text)
        {
            ReadFromText(text, this._encoding);
        }

        public void ReadFromFile(string filePath, Encoding encoding)
        {
            this._encoding = encoding;
            this._data = System.IO.File.ReadAllBytes(filePath);
        }

        public void ReadFromFile(string filePath)
        {
            this.ReadFromFile(filePath, this._encoding == null ? Encoding.Default : this._encoding);
        }
        #endregion

        #region writers
        public void WriteToFile(string filePath)
        {
            System.IO.File.WriteAllBytes(filePath, _data);
        }
        #endregion

        #region converters
        /// <summary>
        /// Конвертировать
        /// </summary>
        /// <returns>Битовый массив, представленный в виде строки</returns>
        public string ToBitArrayString()
        {
            StringBuilder stb = new StringBuilder();
            bool[] ba = this.ToBitArray();
            for (int i = 0; i < ba.Length; i++)
                stb.Append(ba[i] ? '1' : '0');
            return stb.ToString();
        }

        /// <summary>
        /// Конвертировать
        /// </summary>
        /// <returns>Битовый массив</returns>
        public bool[] ToBitArray()
        {
            bool[] ba = new bool[8 * _data.Length];
            for (int i = 0; i < _data.Length; i++)
            {
                for (int j = 7, k = 0; j >= 0; j--, k++)
                {
                    ba[i * 8 + j] = ((_data[i] >> k) & 1) == 1;
                }
            }
            return ba;

        }

        public override string ToString()
        {
            return _data == null || 1 > _data.Length ? string.Empty : _encoding.GetString(_data);
        }
        #endregion

        #region static converters
        private byte[] ToByteArray(BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return bytes;
        }
        #endregion
    }
}
