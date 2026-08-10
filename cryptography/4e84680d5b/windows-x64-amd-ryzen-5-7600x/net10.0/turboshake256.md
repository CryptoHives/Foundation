| Description                                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 128B         |     189.4 ns |   1.20 ns |   1.06 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 128B         |     211.9 ns |   0.97 ns |   0.90 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 128B         |     218.0 ns |   0.56 ns |   0.53 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 137B         |     348.9 ns |   3.33 ns |   3.11 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 137B         |     391.0 ns |   2.02 ns |   1.89 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 137B         |     406.2 ns |   1.24 ns |   1.16 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 1KB          |     976.6 ns |   4.64 ns |   4.34 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 1KB          |   1,233.4 ns |   5.69 ns |   5.32 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 1KB          |   1,297.9 ns |   3.08 ns |   2.88 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 1025B        |     973.5 ns |   4.63 ns |   4.11 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 1025B        |   1,231.7 ns |   3.69 ns |   3.45 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 1025B        |   1,297.0 ns |   3.48 ns |   3.25 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 8KB          |   6,828.8 ns |  35.19 ns |  31.20 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 8KB          |   8,761.6 ns |  17.52 ns |  16.39 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 8KB          |   9,276.7 ns |  20.00 ns |  17.73 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 128KB        | 105,826.9 ns | 495.77 ns | 463.74 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 128KB        | 136,551.6 ns | 410.01 ns | 320.11 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 128KB        | 143,858.0 ns | 426.21 ns | 398.68 ns |     176 B |