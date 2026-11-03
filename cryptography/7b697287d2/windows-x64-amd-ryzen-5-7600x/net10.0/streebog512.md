| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.697 μs | 0.0016 μs | 0.0014 μs |   7,211 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.903 μs | 0.0080 μs | 0.0071 μs |  13,085 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.890 μs | 0.0089 μs | 0.0084 μs |  11,876 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.703 μs | 0.0025 μs | 0.0022 μs |   7,207 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.894 μs | 0.0120 μs | 0.0112 μs |  13,937 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.940 μs | 0.0077 μs | 0.0072 μs |  13,652 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |    10.264 μs | 0.0059 μs | 0.0052 μs |   7,216 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    14.662 μs | 0.0201 μs | 0.0168 μs |  13,174 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    18.815 μs | 0.0607 μs | 0.0538 μs |  11,885 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |    10.356 μs | 0.0097 μs | 0.0081 μs |   7,214 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    14.751 μs | 0.1080 μs | 0.0957 μs |  14,341 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    18.869 μs | 0.0300 μs | 0.0280 μs |  13,682 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    71.020 μs | 0.1003 μs | 0.0939 μs |   7,214 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |   100.873 μs | 0.2605 μs | 0.2309 μs |  13,551 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   130.308 μs | 0.2442 μs | 0.2284 μs |  11,885 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,114.116 μs | 2.4244 μs | 2.2678 μs |   7,252 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,584.401 μs | 2.1105 μs | 1.8709 μs |  13,554 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 2,043.989 μs | 4.2934 μs | 4.0160 μs |  11,895 B |         - |