# 📊 Smart Budget Tracker v1.0

A professional-grade, cross-platform financial CLI tool built with **C# .NET**. Designed for precision, privacy, and ease of use, this application provides comprehensive budget management for both **Linux** and **Windows** environments.

---

## ✨ Key Features

*   **Secure Access**: Integrated local authentication system to protect sensitive financial data.
*   **Automated Persistence**: Seamlessly saves and updates your financial state in a localized data file.
*   **Dynamic Visuals**: Adaptive ASCII interface that optimizes itself to your terminal's dimensions.
*   **Financial Insights**:
    *   Real-time salary and expense tracking.
    *   Smart budget alerts and health status indicators.
    *   **12-Month Predictive Analytics**: Advanced forecasting to visualize your long-term savings growth.

---

## 🛠 Technical Specifications

*   **Language & Runtime**: Powered by **C#** and **.NET SDK**.
*   **Architecture**: Built using robust modular logic for high performance and stability.
*   **Compatibility**: True cross-platform support with dynamic resolution handling to ensure a smooth experience on Linux terminals.
*   **Security**: Local encryption through user-defined passwords during the initial setup.

---

## 🚀 How It Works

1.  **Initialization**: On first launch, the system prompts you to create a secure password and define your baseline monthly income.
2.  **Management**: Use the intuitive menu to log expenses or update your income as your financial situation evolves.
3.  **Analysis**: Access the "Summary" or "Forecast" modules to get instant insights into your spending habits and future wealth.

---

## 📥 Download & Installation

Choose the standalone version for your operating system. No external dependencies are required.

### 1. Download
| Platform | Package | Launch File |
| :--- | :--- | :--- |
| **Windows (x64)** | [BUDGET-TRACKER.Windows.zip](https://github.com/GreatOmar/BUDGET-TRACKER/releases/download/v1.0/BUDGET-TRACKER.Windows.zip) | `BUDGET_TRACKER.exe` |
| **Linux (x64)** | [BUDGET-TRACKER.Linux.tar.gz](https://github.com/GreatOmar/BUDGET-TRACKER/releases/download/v1.0/BUDGET-TRACKER.Linux.tar.gz) | `BUDGET_TRACKER` |

---

### 2. Setup Instructions

#### **🪟 For Windows Users:**
1.  **Extract**: Right-click the `BUDGET-TRACKER.Windows.zip` file and select **"Extract All..."**.
2.  **Open**: Navigate to the extracted folder.
3.  **Run**: Double-click `BUDGET_TRACKER.exe`. 
    *(Note: If Windows SmartScreen appears, click "More info" -> "Run anyway")*.

#### **🐧 For Linux Users:**
1.  **Extract**: Open your terminal and run:
    ```bash
    tar -xvzf BUDGET-TRACKER.Linux.tar.gz
    ```
2.  **Permissions**: Give the binary execution rights:
    ```bash
    chmod +x BUDGET_TRACKER
    ```
3.  **Run**: Execute the app:
    ```bash
    ./BUDGET_TRACKER
    ```

> **Note**: For developers, the source code can be executed directly using `dotnet run` within the project directory.
