# utilities
Executable for routine operations

## Usage

Run the exe file directly from the below folder.

```
\bin\Debug\netcoreapp3.1\CustomPrograms.exe
```

## Motivation

To provide list of files in the proper folder structure to deploy on externally hosted apps. The obvious missing features from the functions is validation. Since the purpose of these functions is to prepare a file package to deploy, it is presumed that only a developer is going to use this and proper input will be provided.

## Functions

- Get file names
	- This method iterates through all files under a directory path provided (including subdirectories) and lists all file names with complete path in file called "filelist.txt". This file is created one directory level up than the source directory.

- Copy files
	- This method only copies those files which are mentioned in the text file provided by user from source to destination. 

- Get line numbers for string match
	- Search CSV file row wise and return rows where string match was found. The matchines rows are exported to "filelist.txt". This file is created one directory level up than the source directory.

## License
[MIT](https://choosealicense.com/licenses/mit/)