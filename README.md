Tax Compliance Audit Engine (.NET/C#)

📋 Project Overview

This is a C# console application designed to simulate the core logic of an enterprise tax compliance system. It processes a batch of taxpayer records, calculates statutory tax liability based on 2025 IRS Marginal Tax Brackets, and identifies compliance variances.

I built this project to prepare for the Implementation Consultant role at Fast Enterprises, demonstrating my ability to translate complex business rules into functional code.

🚀 Key Features

Marginal Tax Logic: Implemented a progressive tax bracket algorithm (10% - 37%) rather than a simple flat-rate calculation, ensuring statutory accuracy.

Standard Deduction: Logic automatically applies the 2025 Standard Deduction ($15,000) to determine true taxable income.

Variance Analysis & UI: The system compares "Tax Paid" vs. "Tax Owed" and triggers specific color-coded workflows:

[AUDIT] (Red): Flags underpayments for review.

[REFUND] (Yellow): Identifies overpayments to issue refunds.

[OK] (Green): Validates compliant accounts.

Object-Oriented Design: Utilizes C# Classes, Lists, and strong typing (including nullable types) to manage taxpayer data structures.

🛠️ Tech Stack

Language: C#

Framework: .NET 8.0 (Console Application)

IDE: Visual Studio Code on macOS

💻 Example Output

When running the compliance check on the current dataset, the console generates the following report:

COMPLIANCE CHECK STARTING NOW......
[REFUND] John Smith OVERPAID BY $1038.50.
[AUDIT]  Kelly Smith UNDERPAID BY $10047.00
[REFUND] Bob Smith OVERPAID BY $21388.50.
[OK]     Joe Smith paid the correct amount.
[OK]     Karen Smith paid the correct amount.


🔧 How to Run

Clone this repository.

Open the folder in your terminal.

Run the following command:

dotnet run