# PupilX

A native Android application for image/frame processing and scientific calculations, optimized for performance and built with modern Android technologies.

## Overview

This application is a standalone native Android app built with Kotlin and the latest Android Jetpack libraries. It provides a robust platform for capturing and processing images, with a focus on scientific calculations and data analysis.

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

## Architecture

The application follows the MVVM (Model-View-ViewModel) architecture pattern, with a single Activity and multiple Composable screens.

-   **MainActivity:** The single entry point of the application. It hosts the NavHost for navigating between screens.
-   **CameraScreen:** A composable screen that displays the camera preview, allows the user to capture images, and navigates to the gallery.
-   **GalleryScreen:** A composable screen that displays a grid of all the captured images.
-   **GalleryViewModel:** A ViewModel that is responsible for loading the images from the MediaStore.
-   **ImageProcessingService:** A service that is responsible for processing the images in the background.

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