| Description                                      | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     751.6 ns |     1.04 ns |   0.97 ns |   9,485 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     809.9 ns |     1.53 ns |   1.36 ns |   4,291 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     749.4 ns |     1.42 ns |   1.32 ns |   9,489 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     814.3 ns |     2.07 ns |   1.84 ns |   4,279 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   4,154.5 ns |     6.93 ns |   6.14 ns |   9,493 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,535.8 ns |    14.12 ns |  12.52 ns |   4,291 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   4,162.9 ns |     8.95 ns |   8.37 ns |   9,494 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,540.1 ns |    10.04 ns |   9.40 ns |   4,284 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  31,404.3 ns |    32.33 ns |  30.24 ns |   9,343 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  34,284.0 ns |    69.97 ns |  62.03 ns |   4,291 B |         - |
|                                                  |              |              |             |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 498,018.6 ns |   437.14 ns | 365.03 ns |   9,456 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 543,770.1 ns | 1,126.89 ns | 998.96 ns |   4,301 B |         - |