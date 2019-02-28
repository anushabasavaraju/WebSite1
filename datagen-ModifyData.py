import MySQLdb
import sys
import random
import traceback
from datetime import datetime, timedelta



def modify_data_insert(data):
    try:
        con = MySQLdb.connect("35.224.47.204", "root", "admin123", "ehrgoogledb")
        cursor = con.cursor()
        print("Inserting", data)
        insert_data = list(data.values())

        cursor.execute("insert into ModifyData(FirstName, LastName, Age, Gender, Birthday, Occupation, UserName, Password, Race, Ethnicity, Smoking, Language, SSN, CreditCardNumber, CVV, ExpiryDate, NameonCard, PersonalID)"
                                            + "VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)", insert_data)
        con.commit()
    except Exception as e:
        print(e)
        # traceback.print_exc()
    finally:
        cursor.close()
        con.close()

FIRSTNAME_PREFIX = "A"
LASTNAME_PREFIX = "Z"
GENDER = ["Male", "Female"]
OCCUPATION = ["Doctor", "Patient", "Provider", "Specialist"]
USERNAME_PREFIX = "aaa"
PASSWORD_SUFFIX = "qq"
RACE = ["Asian", "African"]
ETHNICITY = ["Indian"]
SMOKING = ["No", "Yes"]
LANGUAGE = ["English", "Spanish"]
PERSONALID = ["License", "Passport"]


def gen_datetime(min_year=1900, max_year=datetime.now().year):
    # generate a datetime in format yyyy-mm-dd hh:mm:ss.000000
    start = datetime(min_year, 1, 1)
    years = max_year - min_year + 1
    end = start + timedelta(days=365 * years)
    return start + (end - start) * random.random()


def gen_ssn(n):
    # generate ssn with 10 random numbers
    range_start = 10**(n-1)
    range_end = (10**n)-1
    return random.randint(range_start,range_end)

def gen_expdate():
    year = random.randint(2019, 2025)
    month = random.randint(1, 12)
    day = random.randint(1, 28)
    expiry_date = datetime(year, month, day)
    return expiry_date


def main():
    if len(sys.argv) != 2:
        sys.exit("Please provide number of entries. Example: ./datagen.py 1000")

    number_of_entries = int(sys.argv[1])

    for i in range(number_of_entries):
        data = {
            "FirstName"        : FIRSTNAME_PREFIX + str(i),
            "LastName"         : LASTNAME_PREFIX + str(i),
            "Age"              : random.randint(12,100),
            "Gender"           : random.choice(GENDER),
            "Birthday"         : gen_datetime().strftime("%d-%m-%Y"),
            "Occupation"       : random.choice(OCCUPATION),
            "UserName"         : USERNAME_PREFIX + str(i),
            "Password"         : USERNAME_PREFIX + str(i) + PASSWORD_SUFFIX,
            "Race"             : random.choice(RACE),
            "Ethnicity"        : random.choice(ETHNICITY),
            "Smoking"          : random.choice(SMOKING),
            "Language"         : random.choice(LANGUAGE),
            "SSN"              : gen_ssn(10),
            "CreditCardNumber" : gen_ssn(16),
            "CVV"              : gen_ssn(3),
            "ExpiryDate"       : gen_expdate(),
            "NameonCard"       : FIRSTNAME_PREFIX + LASTNAME_PREFIX + str(i),
            "Personal_ID"      : random.choice(PERSONALID)
        }

        modify_data_insert(data)


if __name__ == "__main__":
    main()
