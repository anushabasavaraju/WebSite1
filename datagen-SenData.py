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


def sensitive_data_insert(data):
    try:
        con = MySQLdb.connect("ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com", "admin", "admin123", "EhrMysqlDb")
        cursor = con.cursor()
        print("Inserting", data)
        insert_data = list(data.values())

        cursor.execute("insert into SensitiveData2(SSN, CreditCardNumber, CVV, ExpiryDate, NameonCard, PersonalID)"
                                            + "VALUES (%s, %s, %s, %s, %s, %s)", insert_data)
        con.commit()
    except Exception as e:
        print(e)
        # traceback.print_exc()
    finally:
        cursor.close()
        con.close()

FIRSTNAME_PREFIX = "A"
LASTNAME_PREFIX = "Z"
PERSONALID = ["License", "Passport"]

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
            "SSN"              : gen_ssn(10),
            "CreditCardNumber" : gen_ssn(16),
            "CVV"              : gen_ssn(3),
            "ExpiryDate"       : gen_expdate(),
            "NameonCard"       : FIRSTNAME_PREFIX + LASTNAME_PREFIX + str(i),
            "Personal_ID"      : random.choice(PERSONALID)
        }

        sensitive_data_insert(data)


if __name__ == "__main__":
    main()
