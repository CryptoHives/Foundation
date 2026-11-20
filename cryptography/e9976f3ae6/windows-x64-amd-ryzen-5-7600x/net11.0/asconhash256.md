| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     673.7 ns |     6.52 ns |     5.44 ns |  13,103 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     899.6 ns |     8.36 ns |     7.82 ns |  14,212 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     715.0 ns |     8.03 ns |     7.51 ns |  12,918 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     950.3 ns |     6.53 ns |     6.11 ns |  14,212 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,373.6 ns |    52.64 ns |    49.24 ns |  13,103 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,855.0 ns |    62.86 ns |    58.80 ns |  14,031 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,396.5 ns |    68.94 ns |    64.49 ns |  12,918 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,858.9 ns |    61.20 ns |    57.25 ns |  14,031 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  34,006.0 ns |   556.58 ns |   520.63 ns |  13,119 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  45,280.0 ns |   498.53 ns |   466.32 ns |  14,246 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 533,194.4 ns | 1,515.72 ns | 1,183.38 ns |   6,594 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 714,701.5 ns | 1,474.67 ns | 1,151.33 ns |  14,067 B |         - |