﻿using System;
using System.Transactions;

namespace UPDPackets.Session
{
    public class WeatherForecastSample
    {
        public const int SIZE = 5;
        public byte m_sessionType;                     // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1
        // 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 10 = R, 11 = R2
        // 12 = Time Trial
        public byte m_timeOffset;                      // Time in minutes the forecast is for
        public byte m_weather;                         // Weather - 0 = clear, 1 = light cloud, 2 = overcast
        // 3 = light rain, 4 = heavy rain, 5 = storm
        public sbyte m_trackTemperature;                // Track temp. in degrees celsius
        public sbyte m_airTemperature;                  // Air temp. in degrees celsius

        public WeatherForecastSample(byte[] bytes)
        {
            m_sessionType = bytes[0];
            m_timeOffset = bytes[1];
            m_weather = bytes[2];
            m_trackTemperature = (sbyte)BitConverter.ToChar(bytes, 3);
            m_airTemperature = (sbyte)BitConverter.ToChar(bytes, 4);
        }
    }
}