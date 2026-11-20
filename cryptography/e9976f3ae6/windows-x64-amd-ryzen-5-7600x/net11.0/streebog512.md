| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.624 μs | 0.0096 μs | 0.0080 μs |  16,397 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.964 μs | 0.0301 μs | 0.0252 μs |  22,141 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.594 μs | 0.0114 μs | 0.0095 μs |  26,726 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.631 μs | 0.0049 μs | 0.0046 μs |  16,212 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.928 μs | 0.0063 μs | 0.0056 μs |  16,897 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.642 μs | 0.0432 μs | 0.0360 μs |  28,206 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |    10.139 μs | 0.0179 μs | 0.0167 μs |   9,877 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    14.750 μs | 0.0697 μs | 0.0618 μs |  22,351 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    17.634 μs | 0.0316 μs | 0.0264 μs |  20,198 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |    10.407 μs | 0.0101 μs | 0.0079 μs |   9,882 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    14.734 μs | 0.0257 μs | 0.0215 μs |  17,309 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    17.723 μs | 0.0281 μs | 0.0235 μs |  21,881 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    68.793 μs | 0.1650 μs | 0.1288 μs |  16,402 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |   101.350 μs | 0.2332 μs | 0.2068 μs |  22,581 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   122.564 μs | 0.1698 μs | 0.1326 μs |  26,680 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,111.586 μs | 1.8716 μs | 1.5629 μs |  16,383 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,591.741 μs | 2.8516 μs | 2.2263 μs |  22,577 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,924.483 μs | 9.3600 μs | 7.8160 μs |  20,176 B |         - |