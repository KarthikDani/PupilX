# PupilX

This project is a native Android implementation of a Unity-based application for image/frame processing and scientific calculations related to pupil response analysis.

## Overview

The original Unity application has been converted to a native Android application using Kotlin. This implementation provides:

- Improved performance through native Android optimizations
- Reduced application size by removing Unity engine dependencies
- Direct access to Android APIs for enhanced functionality
- Better battery efficiency and device integration

## Features

- **Image/Frame Processing**: Efficient processing of pupil response data using Android's native capabilities
- **Scientific Calculations**: Implementation of complex mathematical algorithms for pupil analysis
- **Protocol Management**: Support for multiple testing protocols (Fixed Intensity, Variable Intensity, PIPR, etc.)
- **Data Management**: JSON-based data storage and retrieval
- **Performance Optimizations**: Memory-efficient algorithms and caching mechanisms

## Architecture

The application follows a modular architecture with the following components:

### Managers
- `MainAppManager`: Central coordinator for all protocols
- `CalculationManager`: Handles scientific computations
- `DiameterSmoothingManager`: Processes pupil diameter data
- `DataManager`: Manages data persistence
- `Protocol Managers`: Specialized managers for each testing protocol

### Models
- Data classes representing patient data, test results, and calculation outputs

### Utilities
- `ImageProcessor`: Handles image processing tasks
- `JsonUtils`: JSON serialization/deserialization
- `TestUtils`: Testing utilities

## Performance Optimizations

- Caching of calculation results to avoid redundant computations
- Pre-allocation of collections to reduce garbage collection
- Buffer reuse in image processing to minimize memory allocation
- Efficient algorithms for mathematical computations

## Getting Started

1. Clone the repository
2. Open in Android Studio
3. Build and run the application

## Build Instructions

### Building from the Command Line

To build the application from the command line, run the following command in the root directory of the project:

```bash
./gradlew assembleDebug
```

This will build a debug version of the application. The output APK will be located in `app/build/outputs/apk/debug/`.

## Requirements

- Android SDK 24 or higher
- Android Studio Arctic Fox or newer

---
