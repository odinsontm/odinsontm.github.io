/**
 * Simple shell interface program.
 */

#include <stdio.h>
#include <unistd.h>
#include <string.h>
#include <sys/wait.h>
#include <stdlib.h>


// function prototypes

int parse_command(char command[], char *args[]);

#define MAX_LINE		80 /* 80 chars per line, per command */

int main(void)
{
	char *args[MAX_LINE/2 + 1];	/* command line (of 80) has max of 40 arguments */
   	char *prev[MAX_LINE/2+1];
	int should_run = 1;
	int command_length;
	
	char command[MAX_LINE];
	char previous[MAX_LINE];
	char toCopy[MAX_LINE];
	int trigger;
	int trigger2;

    while (should_run)
    {   
        printf("osh>");
        fflush(stdout);

	    fgets(command, MAX_LINE, stdin);
	 strcpy(toCopy, command);
	    command_length = parse_command(command, args);	
	
   
	trigger = strcmp(args[0], "exit");
	trigger2 = strcmp(args[0], "!!");
	if (trigger == 0){
		should_run = 0;
		break;
	}
	if(trigger2 == 0){
		command_length = parse_command(previous, prev);
	}	
	pid_t pid;

	pid = fork();

	if(pid<0){
		fprintf(stderr, "Fork Failed\n");
		return 1;
	}
	else if (pid == 0){
		int status;
		if(trigger2 == 0)
			status = execvp(prev[0], prev);
		else
			status = execvp(args[0], args);
		if (status == -1){
			printf("Command not found\n");
			exit(1);
		}
	}
	else{
		wait(NULL);
	}	
	if(trigger2 != 0)
		strcpy(previous, toCopy);
    }  
	return 0;
}

/**
 * Parses the command and places each token
 * into args array.
 */
int parse_command(char command[], char *args[])
{
	char *spart = strtok(command, " \n");
	int length = 0;

	while (spart != NULL)
	{
		args[length] = spart;
		length++;
		spart = strtok(NULL, " \n");
	}
	args[length] = NULL;
	length++;	

	return length;
}
