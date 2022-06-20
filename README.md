# MystticScanner
This application allows you to scan local files for threats using the VirusTotal tools for checking.
![image](https://user-images.githubusercontent.com/19372942/174670166-c2d461a9-2db1-4d98-b37d-3d12083b9c1e.png)

## How to use:
The application can download files to be scanned manually or automatically. 
By selecting the "Select file" button, we open the file selection dialog in order to select a file to be scanned.

Selecting a file sends it to the VirusTotal platform for scanning. 
In the reply, we receive an identifier by which we can search for the file sent for scanning.
This identifier is available for viewing on the list next to the file path and after opening the report form by double-clicking on the list.

![image](https://user-images.githubusercontent.com/19372942/174670225-b93331eb-38cb-4775-9113-ec9d3628ad1a.png)

By opening the form, you can download a detailed report on the sent file.
After clicking on the "Get Report" button, a full report with the results of each scanning engine will be displayed below. 
At the very bottom of the report you can see a summary and a shortened report of the results.

![image](https://user-images.githubusercontent.com/19372942/174670256-45566005-f126-4b04-98d8-4325fe9d729d.png)
The application can be set to automatically send files to be scanned if a new file appears in the specified directory. 
To do this, go to the main settings form by clicking the "Settings" button.
There is a list on the form where you can indicate the paths to be monitored.

Additionally, it is possible to set the maximum file size that can be sent for scanning. The value is specified in MB. You can also specify the file extensions to be included.


Additional info:

- Occasionally, the detailed report you receive may not contain any information. If the status of such a report is "queued", it means that the report is waiting to be scanned.
- If "Max file size" is set to 0, the file size will not matter. However, a VirusTotal restriction may apply.
- If the "Enabled file extensions" setting is empty, the file extension will not matter. However, there may be a limitation by VirusTotal in being able to scan certain formats.
