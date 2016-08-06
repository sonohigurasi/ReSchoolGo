using UnityEngine;
using System.Collections;

public struct SubjectDataRecord
{
    public int number; 
    public string name;
    public float date;
    public string detail;
}

public struct PastQuestionRecord
{
    public int number;
    public string imageName;
}

public class Database {

	static SqliteDatabase openDatabase()
    {
        return new SqliteDatabase("database.db");
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
            SubjectDataRecord record;

            record.number = (int)dr["Number"];
            record.name = (string)dr["Name"];
            record.date = (int)dr["Date"];
            record.detail = (string)dr["Detail"];

            records[count] = record;

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
            SubjectDataRecord record;

            record.number = (int)dr["Number"];
            record.name = (string)dr["Name"];
            record.date = (int)dr["Date"];
            record.detail = (string)dr["Detail"];

            records[count] = record;

            count++;
        }

        return records;
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
            PastQuestionRecord record;

            record.number = (int)dr["Number"];
            record.imageName = (string)dr["ImageName"];

            records[count] = record;

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
            PastQuestionRecord record;

            record.number = (int)dr["Number"];
            record.imageName = (string)dr["ImageName"];

            records[count] = record;

            count++;
        }

        return records;
    }
}
