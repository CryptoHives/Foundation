| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.432 μs | 0.0052 μs | 0.0044 μs |   7,702 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.455 μs | 0.0124 μs | 0.0116 μs |  12,467 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.344 μs | 0.0109 μs | 0.0091 μs |  12,234 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.460 μs | 0.0045 μs | 0.0040 μs |   7,702 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.458 μs | 0.0121 μs | 0.0113 μs |  13,055 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.380 μs | 0.0082 μs | 0.0069 μs |  17,671 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     9.269 μs | 0.0160 μs | 0.0141 μs |   7,699 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    13.003 μs | 0.0298 μs | 0.0233 μs |  12,532 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    16.949 μs | 0.0574 μs | 0.0509 μs |  12,235 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     9.239 μs | 0.0103 μs | 0.0086 μs |   7,701 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    13.033 μs | 0.0315 μs | 0.0263 μs |  13,428 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    16.652 μs | 0.0615 μs | 0.0480 μs |  17,678 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    63.341 μs | 0.1355 μs | 0.1201 μs |   7,697 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    89.532 μs | 0.3020 μs | 0.2522 μs |  12,909 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   115.712 μs | 0.3640 μs | 0.3040 μs |  12,229 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,001.294 μs | 4.1851 μs | 3.2674 μs |   7,727 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,401.850 μs | 2.8706 μs | 2.5447 μs |  12,912 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,791.572 μs | 2.5522 μs | 2.1312 μs |  12,222 B |         - |