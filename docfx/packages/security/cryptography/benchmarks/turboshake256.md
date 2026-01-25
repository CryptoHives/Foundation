| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (Managed) | 128B         |     188.6 ns |     1.74 ns |     1.63 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX2)    | 128B         |     214.8 ns |     2.60 ns |     2.30 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX512F) | 128B         |     222.2 ns |     2.05 ns |     1.60 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (Managed) | 137B         |     349.1 ns |     6.46 ns |     6.04 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX2)    | 137B         |     393.3 ns |     5.21 ns |     4.61 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX512F) | 137B         |     413.4 ns |     2.50 ns |     2.34 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (Managed) | 1KB          |   1,000.9 ns |    17.23 ns |    19.15 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX2)    | 1KB          |   1,303.8 ns |    25.05 ns |    34.28 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX512F) | 1KB          |   1,373.4 ns |    26.68 ns |    43.08 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (Managed) | 1025B        |   1,001.5 ns |    19.48 ns |    25.33 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX2)    | 1025B        |   1,290.2 ns |    25.38 ns |    44.44 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX512F) | 1025B        |   1,340.5 ns |    26.59 ns |    40.60 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (Managed) | 8KB          |   6,902.8 ns |   126.71 ns |   112.32 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX2)    | 8KB          |   9,178.0 ns |   181.90 ns |   391.55 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX512F) | 8KB          |   9,459.2 ns |   185.57 ns |   272.00 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (Managed) | 128KB        | 107,356.5 ns | 1,933.57 ns | 1,808.66 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX2)    | 128KB        | 142,027.5 ns | 2,760.61 ns | 5,047.94 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboSHAKE256 (AVX512F) | 128KB        | 148,311.6 ns | 2,934.77 ns | 5,439.79 ns |     176 B |