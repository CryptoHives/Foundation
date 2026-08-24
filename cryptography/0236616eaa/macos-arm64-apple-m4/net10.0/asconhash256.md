| Description                                         | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     671.2 ns |  13.55 ns |  29.16 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     922.4 ns |   0.49 ns |   0.46 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     687.4 ns |   4.98 ns |   4.42 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     973.2 ns |   6.40 ns |   5.99 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,409.2 ns |   0.95 ns |   0.89 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   6,082.0 ns |   8.85 ns |   7.39 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,341.7 ns |   1.77 ns |   1.66 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   6,078.1 ns |   3.08 ns |   2.73 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  34,190.3 ns | 359.22 ns | 336.01 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  47,246.0 ns |  30.27 ns |  25.28 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 540,499.2 ns | 118.76 ns | 105.28 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 754,160.9 ns | 511.52 ns | 427.15 ns |         - |