| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     580.0 ns |     1.46 ns |     1.14 ns |   5,760 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     801.5 ns |     3.01 ns |     2.82 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     618.6 ns |     1.71 ns |     1.43 ns |   5,790 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     829.9 ns |     1.59 ns |     1.41 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   3,748.1 ns |    10.14 ns |     9.49 ns |   5,760 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,100.8 ns |    16.49 ns |    14.62 ns |   6,655 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   3,749.4 ns |    12.57 ns |    11.14 ns |   5,768 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,099.5 ns |    11.47 ns |    10.17 ns |   6,655 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  28,993.3 ns |    36.44 ns |    28.45 ns |   5,774 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  39,600.3 ns |   124.11 ns |   116.09 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 463,714.5 ns | 1,706.25 ns | 1,512.55 ns |   5,716 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 629,466.0 ns |   637.72 ns |   532.52 ns |   6,664 B |         - |