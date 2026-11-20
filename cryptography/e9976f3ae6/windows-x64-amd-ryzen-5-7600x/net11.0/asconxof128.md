| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     664.2 ns |     1.83 ns |     1.62 ns |  13,105 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     888.8 ns |     2.22 ns |     1.96 ns |  13,902 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     717.0 ns |     2.08 ns |     1.84 ns |  13,110 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     934.5 ns |     3.23 ns |     3.02 ns |  13,902 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,291.5 ns |    10.37 ns |     8.10 ns |  12,915 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,735.7 ns |     8.40 ns |     7.44 ns |  13,902 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,300.4 ns |     9.07 ns |     7.57 ns |  12,920 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,738.0 ns |    16.83 ns |    14.05 ns |  14,092 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  33,390.2 ns |   184.96 ns |   163.97 ns |  12,931 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  44,471.1 ns |   106.99 ns |    83.53 ns |  14,092 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 532,996.4 ns | 1,526.37 ns | 1,353.09 ns |   6,596 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 708,185.7 ns | 1,419.86 ns | 1,108.53 ns |  13,913 B |         - |