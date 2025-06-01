# Sortify

Sortify is a utility for automatic file organization based on customizable rules. It helps keep directories clean by sorting files into categorized folders such as Pictures, Documents, and more.

## Features

* Customizable sorting rules via a `config.json` file
* Default config is generated automatically if missing
* Supports categorizing files by any extension
* Automatically renames duplicate files to prevent overwriting

## Getting Started

### Prerequisites

* [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Build

```bash
# Clone the repository
$ git clone https://github.com/LialiukDanylo/Sortify
$ cd Sortify

# Publish a self-contained executable (Windows x64)
$ dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish
```

The executable will be available at `./publish/Sortify.exe`.

### Run

```bash
$ ./publish/Sortify.exe
```

On first run, if no config file is found, a default one will be used. You will be prompted to enter the path of the folder you want to sort.

## Configuration

Configuration is managed via a `config.json` file. Example default:

```json
{
  "SortingRules": {
    "Pictures": [".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp"],
    "Documents": [".pdf", ".docx", ".txt", ".xlsx", ".xml", ".json"],
    "Videos": [".mp4", ".avi", ".mov", ".mkv"],
    "Archives": [".zip", ".rar", ".7z", ".tar"],
    "Music": [".mp3", ".wav", ".flac"]
  }
}
```

## License

MIT License

```
MIT License

Copyright (c) 2025 Lialiuk Danylo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
