| Description                                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128B         |     792.5 ns |     2.76 ns |     2.15 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128B         |     816.4 ns |    10.51 ns |     9.83 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 137B         |     831.3 ns |     6.18 ns |     5.48 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 137B         |     865.2 ns |     8.36 ns |     7.82 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1KB          |   4,890.6 ns |    29.61 ns |    27.70 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1KB          |   4,985.0 ns |    24.78 ns |    23.18 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1025B        |   4,924.0 ns |    46.51 ns |    43.51 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1025B        |   4,982.6 ns |    25.04 ns |    23.42 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 8KB          |  37,493.4 ns |   285.32 ns |   266.89 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 8KB          |  38,650.3 ns |   186.63 ns |   165.44 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128KB        | 596,975.2 ns | 4,061.06 ns | 3,798.71 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128KB        | 614,008.9 ns | 5,163.44 ns | 4,577.25 ns |     112 B |