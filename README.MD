# MacAddressWriter

Created: June 3, 2022\
Last Edited Time: June, 4 2022 10:00AM\
Stakeholders: James Petko\
Status: Complete\
Type: Resume Project\
Author: James Petko (Petko.James@gmail.com)

# Summary
Create_MacAddresses_DB is a .NET Framework Console application that will write a generated MAC address and randomized bool to a MySql Database. This applicaiton is used to generate false data for my 'MacAddressWrite' project. 
MacAddressWrite is a winform applicaiton that will check the MySQL table to determine the next available MAC Address. Then it will write to a chip through a UART/SERIAL connection.

# Background

Application was devised as an answer to a firmware engineering interview question. 

# Goals

Demonstrate proficiency in creating firmware and SQL access through c#.

### Non-Goals

Application is not intended for production of any kind and soley intended for reference.

### Open Questions

Q: What chip can this write to?
A: This application was tested with a Raspberry Pi Zero W. It has not been validtated for any other platform.

### Whats Next
Add alternative programming interfaces aside from just UART. Perhaps something like UDPI with raspberry pi (https://github.com/becky001/Raspberry-Pi-UPDI-Stand-Alone-Programmer && https://github.com/mraardvark/pyupdi.git)


