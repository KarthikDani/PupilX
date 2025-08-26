# PupilX

A native Android application for image/frame processing and scientific calculations, optimized for performance and built with modern Android technologies. This project is undergoing a migration from an existing Unity C# application to a fully native Android platform.

## Overview

This application is a standalone native Android app built with Kotlin and the latest Android Jetpack libraries. It provides a robust platform for capturing and processing images, with a focus on scientific calculations and data analysis, particularly for eye examination protocols.

The application is built with the following technologies:

-   **Kotlin:** The primary programming language.
-   **Jetpack Compose:** For building the user interface.
-   **CameraX:** For camera integration and image capture.
-   **Coroutines:** for managing background threads and asynchronous operations.
-   **Jetpack Navigation:** For navigating between screens.
-   **MVVM Architecture:** The application follows the Model-View-ViewModel architecture pattern.

## Features

-   **Camera Preview:** A real-time camera preview to see what the camera is capturing.
-   **Image Capture:** Capture images from the camera and save them to the device's gallery.
-   **Image Processing:** A basic image processing pipeline with a grayscale filter.
-   **Gallery View:** A gallery screen to view all the captured images.
-   **Modern UI:** A clean and modern user interface built with Jetpack Compose.
-   **Protocol Selection:** A dedicated UI to select and run various eye examination protocols.
-   **Fixed Intensity Protocol (Partial Implementation):** Core logic for the Fixed Intensity protocol has been migrated from C# to Kotlin, including data processing and calculation using dummy data.

## Architecture

The application follows the MVVM (Model-View-ViewModel) architecture pattern, with a single Activity and multiple Composable screens. Key components include:

-   **MainActivity:** The single entry point of the application. It hosts the NavHost for navigating between screens.
-   **CameraScreen:** A composable screen that displays the camera preview, allows the user to capture images, and navigates to the gallery.
-   **GalleryScreen:** A composable screen that displays a grid of all the captured images.
-   **GalleryViewModel:** A ViewModel that is responsible for loading the images from the MediaStore.
-   **ImageProcessingService:** A service that is responsible for processing the images in the background.
-   **BaseProtocolManager:** An abstract base class for all eye examination protocols, providing common functionalities and shared data structures.
-   **DiameterSmoothingManager:** Handles data smoothing and interpolation, including a custom PCHIP (Piecewise Cubic Hermite Interpolating Polynomial) interpolator.
-   **CalculationManager:** Performs various scientific calculations on pupil data, such as velocity, amplitude, and percentage change.
-   **PatientDataRepository:** Manages the loading of patient test data (currently using dummy data).
-   **ResultManager:** Stores and manages the calculated results from various protocols.

## Getting Started

1.  Clone the repository.
2.  Open the project in Android Studio.
3.  Build and run the application.

## Build Instructions

To build the application from the command line, run the following command in the root directory of the project:

```bash
./gradlew assembleDebug
```

The output APK will be located in `app/build/outputs/apk/debug/`.

## Requirements

-   Android SDK 24 or higher.
-   Android Studio Hedgehog or newer.
