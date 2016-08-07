using UnityEngine;
using System.Collections;

public struct SubjectDataRecord
{
    public int number; 
    public string name;
    public float date;
    public string detail;
    public int geoLocationNumber;
}

public struct PastQuestionRecord
{
    public int number;
    public string imageName;
}

public struct GeoLocationRecord
{
    public int number;
    public string name;
    public double latitude;
    public double longitude;
}

public class Database {

	static SqliteDatabase openDatabase()
    {
        return new SqliteDatabase("database.db");
    }

    static SubjectDataRecord  parseSubjectFromRowData(DataRow row)
    {
        SubjectDataRecord record;

        record.number = (int)row["Number"];
        record.name = (string)row["Name"];
        record.date = (int)row["Date"];
        record.detail = (string)row["Detail"];
        record.geoLocationNumber = (int)row["GeoLocationNumber"];

        return record;
    }

    static public SubjectDataRecord[] getAllRecordFromSubjectTable()
    {
        // Select
        string selectQuery = "select * from SubjectTable";
        DataTable dataTable = openDatabase().ExecuteQuery(selectQuery);

        SubjectDataRecord[] records = new SubjectDataRecord[dataTable.Rows.Count];
        int count = 0;
        foreach (DataRow dr in dataTable.Rows)
        {
            records[count] = parseSubjectFromRowData(dr);

            count++;
        }

        return records;
    }

    static public SubjectDataRecord[] getRecordFromSubjectTableBySubjectNumber(int number)
    {
        // Select
        string selectQuery = "select * from SubjectTable where Number = " + number;
        DataTable dataTable = openDatabase().ExecuteQuery(selectQuery);

        SubjectDataRecord[] records = new SubjectDataRecord[dataTable.Rows.Count];
        int count = 0;
        foreach (DataRow dr in dataTable.Rows)
        {
            records[count] = parseSubjectFromRowData(dr);

            count++;
        }

        return records;
    }

    static PastQuestionRecord parsePastQurstionFromRowData(DataRow row)
    {
        PastQuestionRecord record;

        record.number = (int)row["Number"];
        record.imageName = (string)row["ImageName"];

        return record;
    }

    static public PastQuestionRecord[] getAllRecordFromQuestionTable()
    {
        // Select
        string selectQuery = "select * from PastQuestionTable";
        DataTable dataTable = openDatabase().ExecuteQuery(selectQuery);

        PastQuestionRecord[] records = new PastQuestionRecord[dataTable.Rows.Count];
        int count = 0;
        foreach (DataRow dr in dataTable.Rows)
        {
            records[count] = parsePastQurstionFromRowData(dr);

            count++;
        }

        return records;
    }

    static public PastQuestionRecord[] getRecordFromQuestionTableBySubjectNumber(int number)
    {
        // Select
        string selectQuery = "select * from PastQuestionTable inner join SubjectRelationTable on PastQuestionTable.Number = SubjectRelationTable.QuestionNumber where SubjectNumber = " + number;
        DataTable dataTable = openDatabase().ExecuteQuery(selectQuery);

        PastQuestionRecord[] records = new PastQuestionRecord[dataTable.Rows.Count];
        int count = 0;
        foreach (DataRow dr in dataTable.Rows)
        {
            records[count] = parsePastQurstionFromRowData(dr);

            count++;
        }

        return records;
    }

    static public PastQuestionRecord[] getRecordFromQuestionTableByPastQuestionNumber(int number)
    {
        // Select
        string selectQuery = "select * from PastQuestionTable where Number = " + number;
        DataTable dataTable = openDatabase().ExecuteQuery(selectQuery);

        PastQuestionRecord[] records = new PastQuestionRecord[dataTable.Rows.Count];
        int count = 0;
        foreach (DataRow dr in dataTable.Rows)
        {
            records[count] = parsePastQurstionFromRowData(dr);

            count++;
        }

        return records;
    }

    static public PastQuestionRecord[] getRecordFromQuestionTableLessThenNumber(int number)
    {
        // Select
        string selectQuery = "select * from PastQuestionTable where Number <= " + number;
        DataTable dataTable = openDatabase().ExecuteQuery(selectQuery);

        PastQuestionRecord[] records = new PastQuestionRecord[dataTable.Rows.Count];
        int count = 0;
        foreach (DataRow dr in dataTable.Rows)
        {
            records[count] = parsePastQurstionFromRowData(dr);

            count++;
        }

        return records;
    }

    static GeoLocationRecord parseGeoLocationFromRowData(DataRow row)
    {
        GeoLocationRecord record;

        record.number = (int)row["Number"];
        record.name = (string)row["Name"];
        record.latitude = (double)row["Latitude"];
        record.longitude = (double)row["Longitude"];

        return record;
    }

    static public GeoLocationRecord[] getAllRecordFromGeoLocationTable()
    {
        // Select
        string selectQuery = "select * from GeoLocationTable";
        DataTable dataTable = openDatabase().ExecuteQuery(selectQuery);

        GeoLocationRecord[] records = new GeoLocationRecord[dataTable.Rows.Count];
        int count = 0;
        foreach (DataRow dr in dataTable.Rows)
        {
            records[count] = parseGeoLocationFromRowData(dr);

            count++;
        }

        return records;
    }

    static public GeoLocationRecord[] getRecordFromGeoLocationTableByGeoLocationNumber(int number)
    {
        // Select
        string selectQuery = "select * from GeoLocationTable where Number = " + number;
        DataTable dataTable = openDatabase().ExecuteQuery(selectQuery);

        GeoLocationRecord[] records = new GeoLocationRecord[dataTable.Rows.Count];
        int count = 0;
        foreach (DataRow dr in dataTable.Rows)
        {
            records[count] = parseGeoLocationFromRowData(dr);

            count++;
        }

        return records;
    }
}
