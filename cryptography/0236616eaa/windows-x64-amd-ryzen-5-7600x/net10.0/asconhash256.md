| Description                                         | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     573.5 ns |     1.40 ns |   1.31 ns |   5,709 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     782.8 ns |     0.53 ns |   0.44 ns |   6,807 B |         - |
|                                                     |              |              |             |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     603.8 ns |     1.43 ns |   1.27 ns |   5,721 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     823.7 ns |     1.46 ns |   1.22 ns |   6,807 B |         - |
|                                                     |              |              |             |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   3,711.1 ns |     5.35 ns |   4.74 ns |   5,709 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,084.4 ns |    10.57 ns |   8.83 ns |   6,798 B |         - |
|                                                     |              |              |             |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   3,698.8 ns |     7.11 ns |   5.94 ns |   5,721 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,081.0 ns |     8.37 ns |   6.99 ns |   6,807 B |         - |
|                                                     |              |              |             |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  28,668.5 ns |    39.82 ns |  35.30 ns |   5,739 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  39,725.3 ns |    92.08 ns |  71.89 ns |   6,801 B |         - |
|                                                     |              |              |             |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 457,129.3 ns |   462.56 ns | 386.26 ns |   5,681 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 629,361.9 ns | 1,033.93 ns | 916.55 ns |   6,793 B |         - |