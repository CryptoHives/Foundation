| Description                                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128B         |     764.3 ns |     6.86 ns |     6.08 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128B         |     802.1 ns |     3.04 ns |     2.69 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 137B         |     801.6 ns |     5.64 ns |     4.71 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 137B         |     837.0 ns |     1.33 ns |     1.11 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1KB          |   4,644.9 ns |    13.54 ns |    12.66 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1KB          |   5,037.3 ns |    21.28 ns |    19.91 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1025B        |   4,545.2 ns |     7.11 ns |     5.55 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1025B        |   5,029.5 ns |    11.20 ns |     9.93 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 8KB          |  34,785.3 ns |    86.58 ns |    76.75 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 8KB          |  38,756.5 ns |    80.21 ns |    75.03 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128KB        | 547,757.7 ns | 1,235.95 ns | 1,032.08 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128KB        | 617,449.1 ns | 1,898.02 ns | 1,775.41 ns |     112 B |