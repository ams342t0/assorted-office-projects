#include <stdio.h>
#include <conio.h>

#define EMP_ON    	1
#define EMP_OFF   	2
#define DBLS_ON   	3
#define DBLS_OFF  	4
#define SUBS_ON	  	5
#define SUPS_ON	  	6
#define SUP_OFF   	7
#define COMP_ON   	8
#define COMP_OFF  	9
#define DBLWID_ON 	10
#define DBLWID_OFF 	11
#define UNDL_ON    	12
#define UNDL_OFF	13

void FormatOutput(int cmdtype)
{
	switch (cmdtype)
	{
		case EMP_ON:
			fprintf(stdprn,"%c%c",27,69);
			break;

		case EMP_OFF:
			break;

		case DBLS_ON:
			break;
		case DBLS_OFF:
			break;
		case SUBS_ON:
			break;
		case SUPS_ON:
			break;
		case SUP_OFF:
			break;
		case COMP_ON:
			break;
		case COMP_OFF:
			break;
		case DBLWID_ON:
			break;
		case DBLWID_OFF:
			break;
		case UNDL_ON:
			break;
		case UNDL_OFF:
			break;
	}
}

/*
emphasize on 	27,69
emph off 	27,70
dblstrike on	27,71
dblstrike off	27,72
subsc on	27,83,1
supsc on	27,83,0
subs/sups off	27,84
comp on		15
comp off	18
dblwid on	14
dlbwid off	20
undl		27,45,1
undl off	27,45,0


linespacing
1/6"	27,50
1/8"	27,48
7/72"	27,49
n/72"	27,65,n,27,50
	27,65,n
n/216"	27,51,n
exec one line feed of n/216"	27,74,n
default = 1/6"

#define 1_6 	100
#define 1_8	101
#define 7_72	102
#define n_72	103
#define n_216	104

pagelength
n lines		27,67,n
n inches	27,67,79,n
n lines blank
at bottom	27,78,n
cancel perf	27,79
>>>66 lines = 11"

#define N_LINES		200
#define N_INCHES	201
#define N_BOTTOMBLANK	202
#define CANCELPERF	203

*/


inline void DefLineSpace()
{
	fprintf(stdprn,"%c%c",27,50);
}

inline void SkipSpace()
{
	fprintf(stdprn,"\n");
}

inline void LineSpace(char n)
{
	fprintf(stdprn,"%c%c%c",27,65,n);
}


void PrintHeading()
{
	fprintf(stdprn,"%c",18);
	fprintf(stdprn,"   ZAMBOANGA CHONG HUA HIGH SCHOOL\n");
	fprintf(stdprn,"      Gen. V. Alvarez St., Z.C.\n\n");
	fprintf(stdprn,"            BOOK RECEIPT\n");
}

void main(int argc,char **argv)
{
	FILE *fp;
	char sbuffer[100];
	char count;


	if (argc < 2) return;

	fp = fopen (argv[1],"rt");

	PrintHeading();
	fprintf(stdprn,"%c",15);

	DefLineSpace();

	count = 0;

	while (1)
	{

		if (count == 30)
		{
			LineSpace(52);
			SkipSpace();
			DefLineSpace();
			break;
		}
		else
		{
			if (fgets(sbuffer,99,fp))
			{
				fprintf(stdprn,"%s",sbuffer);
			}
			else
			{
				SkipSpace();
			}
		}

		count++;

	}
}