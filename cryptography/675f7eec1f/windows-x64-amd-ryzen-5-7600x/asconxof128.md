| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     574.1 ns |     3.26 ns |     2.89 ns |   5,760 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     783.1 ns |     3.50 ns |     3.11 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     606.5 ns |     5.09 ns |     4.76 ns |   5,768 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     813.2 ns |     4.32 ns |     3.83 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   3,711.2 ns |    13.74 ns |    12.18 ns |   5,782 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,008.1 ns |    28.27 ns |    26.45 ns |   6,655 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   3,718.8 ns |    18.56 ns |    15.50 ns |   5,768 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,013.3 ns |    28.36 ns |    25.14 ns |   6,655 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  28,813.9 ns |   131.92 ns |   116.94 ns |   5,796 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  38,852.8 ns |   152.29 ns |   118.90 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 458,580.1 ns | 2,476.83 ns | 2,195.65 ns |   5,716 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 619,015.5 ns | 2,366.25 ns | 1,975.93 ns |   6,654 B |         - |