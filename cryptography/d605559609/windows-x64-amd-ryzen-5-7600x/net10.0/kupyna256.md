| Description                                      | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 128B         |     2.204 μs |  0.0119 μs |  0.0111 μs |   7,066 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 128B         |     3.379 μs |  0.0195 μs |  0.0153 μs |   5,816 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 137B         |     2.204 μs |  0.0102 μs |  0.0095 μs |   7,061 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 137B         |     3.371 μs |  0.0202 μs |  0.0179 μs |   6,433 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 1KB          |    10.902 μs |  0.0476 μs |  0.0397 μs |   7,061 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 1KB          |    16.896 μs |  0.0769 μs |  0.0682 μs |   5,810 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 1025B        |    10.888 μs |  0.0369 μs |  0.0288 μs |   7,070 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 1025B        |    16.798 μs |  0.1546 μs |  0.1446 μs |   6,428 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 8KB          |    81.251 μs |  0.6777 μs |  0.6008 μs |   7,061 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 8KB          |   124.840 μs |  0.9490 μs |  0.7925 μs |   5,812 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 128KB        | 1,279.988 μs | 20.0221 μs | 18.7287 μs |   7,072 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 128KB        | 1,972.536 μs |  5.5377 μs |  4.9090 μs |   5,822 B |         - |