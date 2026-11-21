| Description                                      | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 128B         |     4.506 μs |  0.0024 μs |  0.0022 μs |  16,250 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 128B         |     6.077 μs |  0.0215 μs |  0.0191 μs |   3,943 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 137B         |     4.494 μs |  0.0039 μs |  0.0036 μs |  16,444 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 137B         |     6.136 μs |  0.0507 μs |  0.0474 μs |   4,717 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 1KB          |    21.806 μs |  0.0109 μs |  0.0096 μs |   9,915 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 1KB          |    30.963 μs |  0.5918 μs |  0.5535 μs |   3,936 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 1025B        |    21.417 μs |  0.0074 μs |  0.0066 μs |  16,254 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 1025B        |    30.239 μs |  0.2704 μs |  0.2529 μs |   4,734 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 8KB          |   157.427 μs |  0.0405 μs |  0.0338 μs |  16,250 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 8KB          |   222.466 μs |  1.3764 μs |  1.1493 μs |   3,951 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 128KB        | 2,536.387 μs |  1.4543 μs |  1.3603 μs |   9,938 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 128KB        | 3,518.164 μs | 21.3823 μs | 17.8552 μs |   3,960 B |         - |