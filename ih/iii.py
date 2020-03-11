import mysql.connector

def open_backend(h,u,p,d):
	global db
	global cur
	try:
		db  = mysql.connector.connect(host=h,user=u,passwd=p,database=d)
		cur = db.cursor()
		print("Connect OK.")
		return 0
	except:
		print("Error connecting to backend.")
		return 1

def close_backend():
	global db
	db.close()



def get_lastid():
	global cur
	try:
		cur.execute('select max(studid) as lastid from students')
		r = cur.fetchone()
		if r[0] == None:
			return 0
		else:
			return r[0]
	except:
		return 0

def add_new(
	email,
	batch,
	fullname,
	level,
	sex,
	school,
	center
	):
	global db
	global cur
	sqlstr = "insert into students(studid,fullname,sex,ilevel,school,center,schedule,s_email," \
	"is_qualified,depslip,is_registered,is_emailed) values(" + \
	str(get_lastid()+1) + "," + \
	enq(fullname) + "," +\
	str(sex) + "," + \
	str(level) + "," +\
 	enq(school) + "," +\
	str(center) + "," +\
	str(batch) + "," +\
	enq(email) + "," + \
	 "-1,-1,0,0);"
	try:
		cur.execute(sqlstr)
		db.commit()
		return 0
	except:
		return 1

def enq(s):
	return '\"' + s + '\"'


