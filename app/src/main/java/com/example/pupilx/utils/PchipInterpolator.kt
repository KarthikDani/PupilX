package com.example.pupilx.utils

import kotlin.math.abs
import kotlin.math.sign

/**
 * Implements a Piecewise Cubic Hermite Interpolating Polynomial (PCHIP) algorithm.
 * This interpolator preserves monotonicity and the shape of the data.
 */
class PchipInterpolator(private val x: List<Float>, private val y: List<Float>) {

    init {
        require(x.size == y.size) { "x and y lists must have the same size" }
        require(x.size >= 2) { "At least two data points are required for interpolation" }
        // Ensure x values are strictly increasing
        for (i in 0 until x.size - 1) {
            require(x[i] < x[i + 1]) { "x values must be strictly increasing" }
        }
    }

    private val slopes: FloatArray = calculateSlopes()

    private fun calculateSlopes(): FloatArray {
        val n = x.size
        val h = FloatArray(n - 1) { i -> x[i + 1] - x[i] }
        val delta = FloatArray(n - 1) { i -> (y[i + 1] - y[i]) / h[i] }
        val m = FloatArray(n)

        // Boundary conditions (using a non-centered, shape-preserving formula)
        m[0] = ((2 * h[0] + h[1]) * delta[0] - h[0] * delta[1]) / (h[0] + h[1])
        if (sign(m[0]) != sign(delta[0])) {
            m[0] = 0f
        } else if (sign(m[0]) != sign(delta[1]) && sign(delta[0]) != sign(delta[1])) {
            m[0] = 3 * delta[0]
        }

        m[n - 1] = ((2 * h[n - 2] + h[n - 3]) * delta[n - 2] - h[n - 2] * delta[n - 3]) / (h[n - 2] + h[n - 3])
        if (sign(m[n - 1]) != sign(delta[n - 2])) {
            m[n - 1] = 0f
        } else if (sign(m[n - 1]) != sign(delta[n - 3]) && sign(delta[n - 2]) != sign(delta[n - 3])) {
            m[n - 1] = 3 * delta[n - 2]
        }

        // Interior points
        for (i in 1 until n - 1) {
            if (delta[i] == 0f || delta[i - 1] == 0f) {
                m[i] = 0f
            } else if (sign(delta[i]) != sign(delta[i - 1])) {
                m[i] = 0f
            } else {
                m[i] = (3 * h[i - 1] * delta[i - 1] + 3 * h[i] * delta[i]) / (h[i - 1] + h[i])
            }
        }
        return m
    }

    /**
     * Interpolates the y-value for a given x-value.
     * @param xi The x-value at which to interpolate.
     * @return The interpolated y-value.
     */
    fun interpolate(xi: Float): Float {
        if (xi < x.first() || xi > x.last()) {
            // Extrapolation: return the nearest known value or throw an error
            // For now, returning the nearest known value.
            return when {
                xi < x.first() -> y.first()
                else -> y.last()
            }
        }

        // Find the interval [x_k, x_{k+1}] that contains xi
        var k = x.binarySearch(xi).let {
            if (it >= 0) it else -it - 2 // If xi is an x-value, it's at index it. Otherwise, it's between -it-1 and -it-2.
        }
        if (k < 0) k = 0 // Handle case where xi is less than the first x value
        if (k >= x.size - 1) k = x.size - 2 // Handle case where xi is greater than or equal to the last x value

        val xk = x[k]
        val yk = y[k]
        val xk1 = x[k + 1]
        val yk1 = y[k + 1]
        val mk = slopes[k]
        val mk1 = slopes[k + 1]
        val hk = xk1 - xk

        val t = (xi - xk) / hk
        val t2 = t * t
        val t3 = t2 * t

        // Hermite polynomial formula
        return (2 * t3 - 3 * t2 + 1) * yk +
                (t3 - 2 * t2 + t) * hk * mk +
                (-2 * t3 + 3 * t2) * yk1 +
                (t3 - t2) * hk * mk1
    }

    /**
     * Interpolates y-values for a list of new x-values.
     * @param newX The list of x-values at which to interpolate.
     * @return A list of interpolated y-values.
     */
    fun interpolate(newX: List<Float>): List<Float> {
        return newX.map { interpolate(it) }
    }
}
