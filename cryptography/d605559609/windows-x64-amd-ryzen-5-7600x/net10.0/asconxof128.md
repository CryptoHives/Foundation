| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     576.9 ns |     4.52 ns |     4.23 ns |   5,760 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     778.8 ns |     1.83 ns |     1.53 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     607.8 ns |     3.69 ns |     3.08 ns |   5,768 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     826.1 ns |    11.76 ns |    10.42 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   3,727.3 ns |    36.77 ns |    34.39 ns |   5,760 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,022.7 ns |    32.39 ns |    28.72 ns |   6,655 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   3,745.9 ns |    74.56 ns |    66.09 ns |   5,768 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,037.0 ns |    53.52 ns |    41.78 ns |   6,655 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  28,909.3 ns |   170.21 ns |   159.21 ns |   5,774 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  38,993.4 ns |   258.55 ns |   241.85 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 458,942.8 ns | 2,725.92 ns | 2,276.27 ns |   5,731 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 623,117.1 ns | 4,123.96 ns | 3,857.56 ns |   6,654 B |         - |