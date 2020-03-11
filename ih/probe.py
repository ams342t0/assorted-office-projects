import os
import gspread
from oauth2client.service_account import ServiceAccountCredentials

c1 = 25
c2 = 34

scope  = ['https://www.googleapis.com/auth/spreadsheets','https://www.googleapis.com/auth/drive']
snames = ['2020 YMIITP - Online Registration (Responses)','2020 Youngster YMIITP - Online (Responses)']

print("Authenticating...")
cred   = ServiceAccountCredentials.from_json_keyfile_name('iii.json',scope)
client = gspread.authorize(cred)
print("Done.")

print("Opening sources...")
s1 = client.open(snames[0]).sheet1
s2 = client.open(snames[1]).sheet1
print("Done.")

print("Gathering data...")
d1 = s1.get_all_values()
d2 = s2.get_all_values()
print("Done.")


fo = open("dump.csv","wt+")


r = raw_input("\nNow what? (1-Dump to screen, 2-Open dump): ")

if (r == '1'):
	do_dump = 1
elif (r == '2'):
	do_dump = 2
else:
	do_dump = 0

if (do_dump == 1):
	print("Large group")

nc1 = 0
umarked = 0

for r in d1:
	s=""
	for c in r:
		s+=c + ";"
	if (r[0] == 'x' and len(r[25]) == 0):
		nc1 +=1

	if (len(r[0]) == 0 and len(r[22])>0):
		umarked +=1

	fo.write((s+"\n").encode("utf-16"))

	if (do_dump==1):
		print(s)


if (do_dump==1):
	print("Other group")

fo.write("\n".encode("utf-16"))

for r in d2:
	s =""
	for c in r:
		s+=c + ";"

	if (r[0]=='x' and len(r[34]) ==0):
		nc1+=1

	if (len(r[0]) == 0 and len(r[31])>0):
		umarked+=1

	fo.write((s+"\n").encode("utf-16"))
	if (do_dump==1):
		print(s)

fo.close()


print("Unmarked : {}".format(umarked))

if (nc1 > 0):
	print("{} new rows.".format(nc1))
else:
	print("Nothing new")


if (do_dump ==2):
	os.system("xdg-open dump.csv")
