import sys
import iii
from datetime import datetime
import gspread
from oauth2client.service_account import ServiceAccountCredentials

#google api credentials
scope =['https://spreadsheets.google.com/feeds','https://www.googleapis.com/auth/drive','https://www.googleapis.com/auth/spreadsheets']

scheds={
'1st Batch (March 28 - 31 2020) - Visayas & Mindanao':1,
'1st Batch (March 28 - 31, 2020) - Visayas & Mindanao':1,
'2nd Batch (April 1 - 4, 2020) - Cavite, Laguna & North Luzon':2,
'3rd Batch (April 5 - 8 2020) - Batangas Lucena Naga Legaspi & NCR':3
}

centers={
"NCR_Philippine Academy of Sakya Center":1,
"NCR_Grace Christian College Center":2,
"NCR_Miriam College Center":3,
"NCR_Las Pinas East National High School center":4,
"NCR_Sen. Rene Cayetano MSTHS Center":5,
"NCR_Novaliches Center":6,
"NCR_St. Paul Pasig Center":7,
"NCR_Makati Center":9,
"NCR_St. Mary's College Center":10,
"NCR_Dee Hwa Liong Center":11,
"SL_St. Paul College - Balayan Center":12,
"NL_St. Paul College of Ilocos Sur Center":13,
"NL_Tarlac Center":14,
"SL_Colegio San Agustin-Binan Center":15,
"SL_Canossa Academy of Calamba Center":16,
"NL_Divine Word Academy Pangasinan Center":17,
"SL_Naga Hope Christian School Center":18,
"SL_University of Sto. Tomas - Legazpi Center":19,
"SL_First Asia Institute of Tech & Humanities Center":20,
"NL_St. Augustine's School":21,
"NL_University of Baguio Center":24,
"SL_Philippine Tong Ho Institute Center":26,
"NL_Santiago Cultural Institute Isabela Center":27,
"NL_BHC Educational Institution Inc. Center":28,
"SL_Palawan Hope Christian School Center":29,
"NL_Agoo Kiddie Special School Center":30,
"NL_Palm Spring Montessori Center":31,
"NL_Jesus Is Lord Colleges Foundation Inc. Center":32,
"NL_Regional Science High School - Region 1 Center":33,
"SL_St. Francis of Assisi College - Bayanan Center":34,
"NL_College of the Immaculate Conception Center":35,
"SL_Bacoor National High School Center":36,
"NL_Shining Light Academy Center":37,
"SL_St. Bridget College Center":38,
"NL_Clarice Angels School Center":39,
"NL_Butterfly Kingdom e-Learning School Center":40,
"NL_Lorma Colleges La Union Center":41,
"NL_Baliuag Bulacan Center":42,
"NL_Vigan Manor Seminary Center":43,
"VIS_Cebu Eastern College Center":44,
"VIS_Iloilo City Center":45,
"VIS_Philippine Science HS Argao Cebu Center":45,
"VIS_Trinity Christian School Center":47,
"VIS_Don Bosco Technical Institute Negros Occ Center":48,
"VIS_Mary Help of Christians School Center":50,
"VIS_Hua Siong College of Iloilo Center":51,
"VIS_Aklan Learning Center":52,
"VIS_St. Anthony's College Antique Center":53,
"VIS_Bohol Wisdom School Center":54,
"VIS_Holy Cross High School Dumaguete Center":55,
"VIS_Fellowship Baptist College Kabankalan Center":56,
"VIS_Sta. Teresa National HS Guimaras Center":57,
"MIN_Zamboanga Center":59,
"MIN_Davao Center":60,
"MIN_Butuan Center":61,
"MIN_Cagayan De Oro City Center":62,
"MIN_Koronadal City Center":63,
"MIN_General Santos City Center":64,
"SL_Cabuyao Laguna Center":65,
"MIN_Agusan Center":66,
"VIS_HERCOR College Roxas City Center":100,
"NL_Immaculate Concepcion Academy center":101,
"SL_International British Academy Imus Center":102,
"NCR_La Immaculada Concepcion School Center":103,
"NL_Olongapo City Center":104,
"VIS_Philippine Science High School-EVC Center":105,
"NL_St. Paul College of Bocaue Center":106,
"NL_St. Paul College of the Philippines Center":107
}

levels={
"Grade 1":1,
"Grade 2":2,
"Grade 3":3,
"Grade 4":4,
"Grade 5":5,
"Grade 6":6,
"Grade 7":7,
"Grade 8":8,
"Grade 9":9,
"Grade 10":10,
"Grade 11":11,
"Grade 12":12
}


f={'paid':0,
'timestamp':1,
'email':2,
'batch':3,
'lastname':5,
'firstname':6,
'middlename':7,
'sex':9,
'level':10,
'school':12,
'center':15,
'SID':24,
'rem':25,
'sid2':33,
'rem2':34}

sex={"Male":1,"Female":2}

def open_backend(h,u,p,d):
	global db
	global cur
	try:
		db  = mysql.connector.connect(host=h,user=u,passwd=p,database=d)
		cur = db.cursor()
		print("Connect OK.")
	except:
		print("Error connecting to backend.")

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
		return 1
	except:
		return 0

def enq(s):
	return '\"' + s + '\"'



def fv(fn,r):
	global f
	global data
	return data[r][f[fn]]



def end_all(m):
	print(m)
	sys.exit()


def do_probe():
	global data
	data = sheet.get_all_values()
	num_rows   = len(data)

	

try:
	creds = ServiceAccountCredentials.from_json_keyfile_name('iii.json', scope)
	client = gspread.authorize(creds)
	print("OK. Credentials authorized.\n")
except:
	end_all("Can't authenticate credentials. Exiting.")

try:
	sheet = client.open("2020 YMIITP - Online Registration (Responses)").sheet1
	sheetyg = client.open('2020 Youngster YMIITP - Online (Responses)').sheet1
	print("Sheets opened")
except:
	end_all("Can't open sheets. Exiting")

r = iii.open_backend('192.168.1.226','mu','mtgp.32768','ih20')

if r == 1:
	end_all("Can't open backend. Exiting")


log = open("log.txt","a+")



#do other levels
data = sheet.get_all_values()
num_rows   = len(data)

add_count = 0

print("Doing other g, Rows: {}".format(num_rows))

for r in range(1,num_rows):
	lid = iii.get_lastid()+1;
	lev = levels[data[r][f['level']]]
	center = centers[data[r][f['center']]]
	sched = scheds[data[r][f['batch']]]
	fullname = fv('lastname',r) + ", " + fv('firstname',r) + " " + fv('middlename',r)
	paid = fv('paid',r)
	imp = fv('rem',r)

	if (paid.upper() == 'X') and (len(imp) == 0):
	
		rv = iii.add_new(fv('email',r),sched,fullname.upper(),lev,sex[fv('sex',r)],fv('school',r),center)
		dt = datetime.now()

		if (rv == 0):
			add_count+=1
			sheet.update_cell(r+1,25,str(lid).zfill(5))
			sheet.update_cell(r+1,26,"Imported")
			log.write(str(dt) + " : Success adding " + fullname.upper() + " Row " + str(r+1) + "\n")
			print("Add ok: " + fullname.upper())
		else:
			log.write(str(dt) + " : Error Adding: " + fullname.upper() + " Row " + str(r+1) + "\n")
			print("Add error." + fullname.upper())




#do g 1 & 2
data = sheetyg.get_all_values()
num_columns = len(data[0])
num_rows   = len(data)

print("Doing YG Group, Rows: {}".format(num_rows))

for r in range(1,num_rows):
	lid = iii.get_lastid()+1;
	lev = levels[data[r][f['level']]]
	center = centers[data[r][f['center']]]
	sched = scheds[data[r][f['batch']]]
	fullname = fv('lastname',r) + ", " + fv('firstname',r) + " " + fv('middlename',r)
	paid = fv('paid',r)
	imp = fv('rem2',r)

	if (paid.upper() == 'X') and (len(imp) == 0):
		rv = iii.add_new(fv('email',r),sched,fullname.upper(),lev,sex[fv('sex',r)],fv('school',r),center)
		dt = datetime.now()

		if (rv == 0):
			add_count+=1
			sheetyg.update_cell(r+1,34,str(lid).zfill(5))
			sheetyg.update_cell(r+1,35,"Imported")
			log.write(str(dt) + " : Success adding " + fullname.upper() + " Row " + str(r+1) + "\n")
			print("Add ok: " + fullname.upper())
		else:
			log.write(str(dt) + " : Error Adding: " + fullname.upper() + " Row " + str(r+1) + "\n")
			print("Add error." + fullname.upper())


log.close()
print("\n{0} added.".format(add_count))
