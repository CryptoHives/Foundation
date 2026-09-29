| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     669.7 ns |     7.08 ns |     6.62 ns |   4,037 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     900.1 ns |     7.17 ns |     6.71 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     710.4 ns |     5.95 ns |     5.57 ns |   4,065 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     945.4 ns |     7.50 ns |     7.02 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,331.4 ns |    64.35 ns |    60.19 ns |   4,037 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,799.8 ns |    55.39 ns |    51.82 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,344.5 ns |    66.85 ns |    62.54 ns |   4,065 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,799.5 ns |    67.39 ns |    63.04 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  33,749.5 ns |   420.68 ns |   393.51 ns |   4,062 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  45,000.2 ns |   538.60 ns |   503.80 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 536,823.7 ns | 7,505.08 ns | 6,653.06 ns |   3,988 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 719,259.2 ns | 8,715.36 ns | 8,152.35 ns |   4,911 B |         - |