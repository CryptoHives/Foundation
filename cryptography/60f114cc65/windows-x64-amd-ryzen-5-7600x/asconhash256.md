| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · Managed      | 128B         |     570.4 ns |     4.23 ns |     3.96 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128B         |     766.4 ns |     2.88 ns |     2.69 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 137B         |     602.0 ns |     4.54 ns |     4.24 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 137B         |     808.3 ns |     5.77 ns |     5.12 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1KB          |   3,676.7 ns |     9.80 ns |     8.18 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1KB          |   5,012.8 ns |    63.01 ns |    55.86 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1025B        |   3,696.0 ns |    35.47 ns |    31.45 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1025B        |   4,984.5 ns |    25.48 ns |    22.59 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 8KB          |  28,556.8 ns |    87.04 ns |    72.68 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 8KB          |  38,653.6 ns |   240.43 ns |   224.90 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 128KB        | 455,118.2 ns | 2,126.41 ns | 1,660.16 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128KB        | 617,096.8 ns | 3,219.04 ns | 2,853.60 ns |         - |