| Description                                         | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     575.3 ns |   0.99 ns |   0.92 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     786.1 ns |   1.38 ns |   1.29 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     607.5 ns |   1.19 ns |   1.05 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     823.7 ns |   0.91 ns |   0.85 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   3,704.7 ns |   2.80 ns |   2.19 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,096.4 ns |   8.52 ns |   7.11 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   3,716.5 ns |   5.96 ns |   5.28 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,100.3 ns |   6.46 ns |   6.04 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  28,810.1 ns |  46.19 ns |  40.94 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  39,537.3 ns |  56.14 ns |  49.77 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 458,510.0 ns | 811.03 ns | 718.96 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 631,577.0 ns | 558.54 ns | 466.41 ns |         - |