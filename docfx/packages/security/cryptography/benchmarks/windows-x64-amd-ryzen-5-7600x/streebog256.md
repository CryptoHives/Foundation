| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.387 μs | 0.0057 μs | 0.0050 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.455 μs | 0.0207 μs | 0.0172 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.276 μs | 0.0219 μs | 0.0205 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.415 μs | 0.0041 μs | 0.0034 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.453 μs | 0.0151 μs | 0.0141 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.316 μs | 0.0796 μs | 0.0706 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     9.191 μs | 0.0225 μs | 0.0210 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    12.788 μs | 0.0508 μs | 0.0475 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    16.401 μs | 0.0298 μs | 0.0265 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     9.151 μs | 0.0242 μs | 0.0214 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    12.816 μs | 0.0760 μs | 0.0674 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    16.257 μs | 0.1049 μs | 0.0930 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    63.177 μs | 0.0906 μs | 0.0803 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    87.512 μs | 0.5581 μs | 0.5221 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   112.292 μs | 0.7803 μs | 0.6092 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   992.181 μs | 2.6164 μs | 2.3193 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,364.872 μs | 3.3761 μs | 2.8192 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,754.045 μs | 7.3392 μs | 6.8651 μs |         - |