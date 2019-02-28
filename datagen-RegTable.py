import MySQLdb
import sys
import random
import traceback
from datetime import datetime, timedelta


def md5_db_insert(data):
    con = MySQLdb.connect("35.224.47.204", "root", "admin123", "ehrgoogledb")
    cursor = con.cursor()
    cursor.execute("insert into data(md5_partial) VALUES (%s)", [data])
    con.commit()
    cursor.close()
    con.close()


def registration_details_insert(data):
    try:
        con = MySQLdb.connect("35.224.47.204", "root", "admin123", "ehrgoogledb")
        cursor = con.cursor()
        print("Inserting", data)
        insert_data = list(data.values())

        cursor.execute("insert into RegistrationDetails(FirstName, LastName, Age, Gender, Occupation, UserName, Password)"
                                            + "VALUES (%s, %s, %s, %s, %s, %s, %s)", insert_data)
        con.commit()
    except Exception as e:
        print(e)
        # traceback.print_exc()
    finally:
        cursor.close()
        con.close()

FIRSTNAME_PREFIX = "P"
LASTNAME_PREFIX = "Q"
GENDER = ["Male", "Female"]
OCCUPATION = ["Doctor", "Patient", "Specialist", "Provider"]
USERNAME_PREFIX = "P"
PASSWORD_SUFFIX = "RRR"


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
            "FirstName" : FIRSTNAME_PREFIX + str(i),
            "LastName"  : LASTNAME_PREFIX + str(i),
            "Age"       : random.randint(12, 100),
            "Gender"    : random.choice(GENDER),            
            "Occupation": random.choice(OCCUPATION),
            "UserName"  : USERNAME_PREFIX + str(i),
            "Password"  : FIRSTNAME_PREFIX + str(i) + PASSWORD_SUFFIX
        }

        registration_details_insert(data)


if __name__ == "__main__":
    main()
