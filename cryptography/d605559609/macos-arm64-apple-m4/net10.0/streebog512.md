| Description                                        | TestDataSize | Mean         | Error     | StdDev     | Median       | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|-----------:|-------------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.978 μs | 0.0385 μs |  0.0501 μs |     1.982 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.604 μs | 0.0706 μs |  0.0989 μs |     3.615 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.304 μs | 0.0263 μs |  0.0246 μs |     4.316 μs |         - |
|                                                    |              |              |           |            |              |           |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.959 μs | 0.0027 μs |  0.0021 μs |     2.959 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.809 μs | 0.0032 μs |  0.0025 μs |     3.809 μs |         - |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     4.709 μs | 1.1902 μs |  3.5092 μs |     2.106 μs |         - |
|                                                    |              |              |           |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     7.062 μs | 0.0026 μs |  0.0021 μs |     7.061 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.214 μs | 0.0110 μs |  0.0097 μs |    11.214 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    14.543 μs | 0.2893 μs |  0.7772 μs |    14.075 μs |         - |
|                                                    |              |              |           |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     7.066 μs | 0.0040 μs |  0.0036 μs |     7.064 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.403 μs | 0.2270 μs |  0.4688 μs |    11.185 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    13.892 μs | 0.0095 μs |  0.0079 μs |    13.890 μs |         - |
|                                                    |              |              |           |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    48.772 μs | 0.0073 μs |  0.0065 μs |    48.772 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    78.353 μs | 0.5140 μs |  0.4292 μs |    78.540 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   114.745 μs | 6.0880 μs | 17.0714 μs |   102.179 μs |         - |
|                                                    |              |              |           |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   767.112 μs | 0.8883 μs |  0.6935 μs |   766.980 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,215.333 μs | 1.4395 μs |  1.3465 μs | 1,215.723 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,405.682 μs | 2.6912 μs |  2.3857 μs | 1,404.915 μs |         - |