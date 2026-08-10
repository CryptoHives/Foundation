| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     571.6 ns |     5.25 ns |     4.65 ns |   5,709 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     776.8 ns |     4.49 ns |     4.20 ns |   6,807 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     604.2 ns |     3.37 ns |     2.99 ns |   5,721 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     817.9 ns |     2.69 ns |     2.39 ns |   6,807 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   3,701.2 ns |    14.78 ns |    13.11 ns |   5,709 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,061.4 ns |    31.35 ns |    29.32 ns |   6,807 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   3,702.4 ns |    16.70 ns |    14.81 ns |   5,721 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,050.9 ns |    21.69 ns |    19.22 ns |   6,798 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  28,719.8 ns |   139.66 ns |   123.80 ns |   5,739 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  39,307.2 ns |   224.92 ns |   199.39 ns |   6,791 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 458,953.7 ns | 2,463.32 ns | 2,304.19 ns |   5,681 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 627,639.5 ns | 4,828.90 ns | 4,516.96 ns |   6,793 B |         - |