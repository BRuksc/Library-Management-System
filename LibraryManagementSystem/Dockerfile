# Use the appropriate Windows base image (e.g., mcr.microsoft.com/dotnet/sdk:5.0-windowsservercore-ltsc2019)
FROM mcr.microsoft.com/dotnet/sdk:5.0-windowsservercore-ltsc2019

# Set the working directory inside the container
WORKDIR /app

# Copy the entire content of the current directory into the container
COPY . .

# Build the WPF project inside the container
RUN dotnet build -c Release

# Set the entry point for the application (adjust the executable name if needed)
ENTRYPOINT ["dotnet", "LibraryManagementSystem.dll"]