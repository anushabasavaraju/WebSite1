import MySQLdb
import sys
import random
import traceback
from datetime import datetime, timedelta


def patient_details_insert(data):
    try:
        con = MySQLdb.connect("35.224.47.204", "root", "admin123", "ehrgoogledb")
        cursor = con.cursor()
        print("Inserting", data)
        insert_data = list(data.values())

        cursor.execute("insert into PatientDetails(FirstName, LastName, Gender, Birthday, Race, Ethnicity, Smoking, Language)"
                                            + "VALUES (%s, %s, %s, %s, %s, %s, %s, %s)", insert_data)
        con.commit()
    except Exception as e:
        print(e)
        # traceback.print_exc()
    finally:
        cursor.close()
        con.close()

FIRSTNAME_PREFIX = "G"
LASTNAME_PREFIX = "K"
GENDER = ["Male", "Female"]
RACE = ["Asian", "African"]
ETHNICITY = ["Indian"]
SMOKING = ["No", "Yes"]
LANGUAGE = ["English", "Spanish"]


def gen_datetime(min_year=1900, max_year=datetime.now().year):
    # generate a datetime in format yyyy-mm-dd hh:mm:ss.000000
    start = datetime(min_year, 1, 1)
    years = max_year - min_year + 1
    end = start + timedelta(days=365 * years)
    return start + (end - start) * random.random()


def main():
    if len(sys.argv) != 2:
        sys.exit("Please provide number of entries. Example: ./datagen.py 1000")

    number_of_entries = int(sys.argv[1])

    for i in range(number_of_entries):
        data = {
            "FirstName": FIRSTNAME_PREFIX + str(i),
            "LastName" : LASTNAME_PREFIX + str(i),
            "Gender"   : random.choice(GENDER),
            "Birthday" : gen_datetime().strftime("%d-%m-%Y"),
            "Race"     : random.choice(RACE),
            "Ethnicity": random.choice(ETHNICITY),
            "Smoking"  : random.choice(SMOKING),
            "Language" : random.choice(LANGUAGE)
        }

        patient_details_insert(data)


if __name__ == "__main__":
    main()
