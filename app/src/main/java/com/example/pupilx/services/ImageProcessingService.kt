package com.example.pupilx.services

import android.content.Context
import android.graphics.Bitmap
import android.graphics.Canvas
import android.graphics.ColorMatrix
import android.graphics.ColorMatrixColorFilter
import android.graphics.ImageDecoder
import android.graphics.Paint
import android.net.Uri
import android.os.Build
import androidx.annotation.RequiresApi
import com.example.pupilx.data.ImageData
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext

class ImageProcessingService(private val context: Context) {

    @RequiresApi(Build.VERSION_CODES.P)
    suspend fun processImage(imageData: ImageData): Bitmap? {
        return withContext(Dispatchers.IO) {
            try {
                val source = ImageDecoder.createSource(context.contentResolver, imageData.uri)
                val bitmap = ImageDecoder.decodeBitmap(source)

                val grayscaleBitmap = bitmap.copy(Bitmap.Config.ARGB_8888, true)
                val canvas = Canvas(grayscaleBitmap)
                val paint = Paint()
                val colorMatrix = ColorMatrix()
                colorMatrix.setSaturation(0f)
                val filter = ColorMatrixColorFilter(colorMatrix)
                paint.colorFilter = filter
                canvas.drawBitmap(bitmap, 0f, 0f, paint)

                grayscaleBitmap
            } catch (e: Exception) {
                null
            }
        }
    }
}