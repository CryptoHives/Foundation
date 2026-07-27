| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.414 μs |  0.0149 μs |  0.0132 μs |   7,699 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.452 μs |  0.0337 μs |  0.0299 μs |  12,467 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.340 μs |  0.0194 μs |  0.0151 μs |  12,229 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.435 μs |  0.0103 μs |  0.0091 μs |   7,702 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.443 μs |  0.0145 μs |  0.0113 μs |  13,055 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.433 μs |  0.0276 μs |  0.0244 μs |  17,671 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     9.178 μs |  0.0260 μs |  0.0231 μs |   7,699 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    12.948 μs |  0.0693 μs |  0.0579 μs |  12,532 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    16.935 μs |  0.1640 μs |  0.1370 μs |  12,238 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     9.245 μs |  0.0337 μs |  0.0315 μs |   7,701 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    12.985 μs |  0.0656 μs |  0.0582 μs |  13,428 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    16.630 μs |  0.1173 μs |  0.1097 μs |  17,701 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    62.145 μs |  0.2523 μs |  0.2236 μs |   7,697 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    89.556 μs |  1.1605 μs |  1.0856 μs |  12,909 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   113.945 μs |  0.8887 μs |  0.7878 μs |  12,229 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,003.615 μs |  6.6809 μs |  5.9225 μs |   7,727 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,402.334 μs | 12.5931 μs | 11.7796 μs |  12,912 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,846.281 μs | 12.0200 μs | 11.2435 μs |  12,222 B |         - |