﻿using Microsoft.ML.Data;

namespace OneApp_minimalApi.Models.MachineLearning
{
    public class MlFileNamePrediction
    {
        [ColumnName("PredictedLabel")]
        public string Area;

        [ColumnName("Score")]
        public float[] Score { get; set; }
    }
}