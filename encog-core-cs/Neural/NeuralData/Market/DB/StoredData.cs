﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.Neural.NeuralData.Market.DB;
using Encog.Neural.NeuralData.Market.DB.Loader.YahooFinance;
using Encog.Util.Time;

namespace Encog.Neural.NeuralData.Market.DB
{
    [Serializable]
    public class StoredData: IComparable<StoredData>
    {
        private ulong date;
        private uint time;

        public DateTime Date
        {
            get
            {
                if (this.date == 0)
                    return YahooDownload.EARLIEST_DATE;
                else
                    return NumericDateUtil.Long2DateTime(this.date);
            }
            set
            {
                this.date = NumericDateUtil.DateTime2Long(value);
            }
        }

        public DateTime Time
        {
            get
            {
                if (this.time == 0)
                    return Date;
                else
                    return NumericDateUtil.Int2Time(this.Date, this.time);
            }
            set
            {
                this.time = NumericDateUtil.Time2Int(value);
            }
        }

        public ulong EncodedDate
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public uint EncodedTime
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public int CompareTo(StoredData other)
        {
            int result = this.date.CompareTo(other.date);
            if (result == 0)
            {
                return this.time.CompareTo(other.time);
            }
            else
            {
                return result;
            }
        }
    }
}