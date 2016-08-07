using UnityEngine;
using System.Collections;
using System;

struct LocationCoordinate {
    public float 
        longitude, //経度
        latitude; //緯度

    public LocationCoordinate(float longitude, float latitude) {
        this.longitude = longitude;
        this.latitude = latitude;
    }

    //2点間の距離を得る(単位:km)
    public static double DistanceLocations(LocationCoordinate location1, LocationCoordinate location2) {
        double deltaX = (location2.longitude - location1.longitude);
        double R = 6378.137f; //地球の半径
        var distance = R * Math.Acos(Math.Sin(location1.latitude) * Math.Sin(location2.latitude) +
            Math.Cos(location1.latitude) * Math.Cos(location2.latitude) * Math.Cos(deltaX));
        return distance;
    }

    /// <summary>
    /// 度単位から等価なラジアン単位に変換します。
    /// </summary>
    /// <param name="deg">度単位</param>
    /// <returns></returns>
    static double deg2rad(double deg) {
        return (deg / 180) * Math.PI;
    }

    /// <summary>
    /// 2点間の位置情報から距離を求める
    /// </summary>
    /// <param name="posA"></param>
    /// <param name="posB"></param>
    /// <returns></returns>
    public static int CalculateDistance(LocationCoordinate posA, LocationCoordinate posB) {
        // 2点の緯度の平均
        double latAvg = deg2rad(posA.latitude + ((posB.latitude - posA.latitude) / 2));
        // 2点の緯度差
        double latDifference = deg2rad(posA.latitude - posB.latitude);
        // 2点の経度差
        double lonDifference = deg2rad(posA.longitude - posB.longitude);

        double curRadiusTemp = 1 - 0.00669438 * Math.Pow(Math.Sin(latAvg), 2);
        // 子午線曲率半径
        double meridianCurvatureRadius = 6335439.327 / Math.Sqrt(Math.Pow(curRadiusTemp, 3));
        // 卯酉線曲率半径
        double primeVerticalCircleCurvatureRadius = 6378137 / Math.Sqrt(curRadiusTemp);

        // 2点間の距離
        double distance = Math.Pow(meridianCurvatureRadius * latDifference, 2)
            + Math.Pow(primeVerticalCircleCurvatureRadius
            * Math.Cos(latAvg) * lonDifference, 2);
        distance = Math.Sqrt(distance);

        return (int)Math.Round(distance);
    }

    //2点間の角度を得る
    public static double AngleLocations(LocationCoordinate location1, LocationCoordinate location2) {
        float deltaX = Math.Abs(location1.longitude - location2.longitude);
        var angle = 90.0 - Math.Atan2(Math.Sin(deltaX),
            Math.Cos(location1.latitude) * Math.Tan(location2.latitude) -
             Math.Sin(location1.latitude) * Math.Cos(deltaX));
        return angle;
    }
}

struct QuestInfo {
    public int questID;
    public int questType; //居るだけで経験値になるポイントでは1、チェックイン式は0
    public string questName;
    public string questDescription;
    public int startTime, endTime; //クエストの出現開始時刻と終了時刻(sec)
}

struct QuestPlaceInfo {
    private LocationCoordinate _location;
    private QuestInfo _questInfo;
    public LocationCoordinate location {
        get { return _location; }
    }
    public QuestInfo questInfo {
        get { return _questInfo; }
    }

    public QuestPlaceInfo(LocationCoordinate locate, QuestInfo quest) {
        this._location = locate;
        this._questInfo = quest;
    }
}

/*
public class DataStructs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
*/