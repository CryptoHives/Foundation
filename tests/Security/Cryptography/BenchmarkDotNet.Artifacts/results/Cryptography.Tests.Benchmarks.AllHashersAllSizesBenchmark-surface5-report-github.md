```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                                | TestDataSize | Mean           | Error         | StdDev        | Median         | Allocated |
|----------------------------------------------------------- |------------- |---------------:|--------------:|--------------:|---------------:|----------:|
| **ComputeHash | BLAKE2b-512 | BouncyCastle**                   | **128B**         |       **147.2 ns** |       **2.18 ns** |       **2.04 ns** |       **147.0 ns** |     **176 B** |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 128B         |       156.2 ns |       1.78 ns |       1.67 ns |       156.3 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 128B         |       264.1 ns |       1.67 ns |       1.39 ns |       264.3 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 137B         |       248.0 ns |       2.11 ns |       1.98 ns |       247.3 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 137B         |       271.6 ns |       2.32 ns |       2.17 ns |       272.3 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 137B         |       501.5 ns |       4.51 ns |       4.00 ns |       500.4 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 1KB          |       853.0 ns |       5.85 ns |       5.47 ns |       854.0 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 1KB          |       921.5 ns |       6.89 ns |       6.44 ns |       921.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 1KB          |     1,984.4 ns |      38.54 ns |      61.12 ns |     1,955.8 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 1025B        |       967.0 ns |      14.75 ns |      12.31 ns |       966.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 1025B        |     1,041.7 ns |      11.69 ns |      10.94 ns |     1,040.0 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 1025B        |     2,207.7 ns |      25.07 ns |      22.22 ns |     2,202.9 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 8KB          |     6,428.9 ns |      59.27 ns |      55.44 ns |     6,441.7 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 8KB          |     7,205.9 ns |     102.96 ns |     126.45 ns |     7,191.7 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 8KB          |    15,545.4 ns |     118.85 ns |      92.79 ns |    15,559.8 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 128KB        |   104,187.3 ns |   1,077.06 ns |   1,007.48 ns |   104,155.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 128KB        |   112,131.9 ns |     879.93 ns |     823.08 ns |   112,009.8 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 128KB        |   248,452.2 ns |   1,700.24 ns |   1,507.22 ns |   248,265.5 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 128B         |       209.6 ns |       1.99 ns |       1.86 ns |       209.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 128B         |       213.6 ns |       1.44 ns |       1.28 ns |       213.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 128B         |       214.0 ns |       4.32 ns |       5.31 ns |       212.0 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 128B         |       240.0 ns |       1.16 ns |       1.03 ns |       240.0 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 128B         |       397.8 ns |       1.81 ns |       1.51 ns |       397.4 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 137B         |       310.1 ns |       1.22 ns |       1.02 ns |       310.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 137B         |       311.4 ns |       1.77 ns |       1.66 ns |       311.0 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 137B         |       337.1 ns |       6.73 ns |      17.13 ns |       338.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 137B         |       356.1 ns |       2.12 ns |       1.98 ns |       356.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 137B         |       576.6 ns |       3.72 ns |       3.30 ns |       576.0 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 1KB          |     1,522.3 ns |      12.74 ns |      10.64 ns |     1,524.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 1KB          |     1,729.7 ns |      26.85 ns |      28.73 ns |     1,741.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 1KB          |     1,757.1 ns |      10.54 ns |       8.80 ns |     1,755.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 1KB          |     2,042.7 ns |      40.91 ns |      88.94 ns |     2,003.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 1KB          |     3,645.4 ns |      44.08 ns |      41.23 ns |     3,635.3 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 1025B        |     1,611.4 ns |      22.47 ns |      21.02 ns |     1,604.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 1025B        |     1,818.5 ns |      12.39 ns |      10.34 ns |     1,819.0 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 1025B        |     2,087.3 ns |     124.18 ns |     366.14 ns |     1,924.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 1025B        |     2,113.9 ns |      35.23 ns |      32.96 ns |     2,103.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 1025B        |     3,849.6 ns |      74.86 ns |      73.53 ns |     3,813.6 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 8KB          |    11,558.6 ns |      52.63 ns |      43.95 ns |    11,546.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 8KB          |    12,865.9 ns |     159.25 ns |     148.96 ns |    12,830.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 8KB          |    13,301.9 ns |     149.02 ns |     132.10 ns |    13,278.5 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 8KB          |    15,427.1 ns |     225.12 ns |     210.58 ns |    15,434.0 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 8KB          |    28,163.7 ns |     427.73 ns |     357.18 ns |    28,149.3 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 128KB        |   184,593.0 ns |   2,184.24 ns |   1,936.27 ns |   184,432.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 128KB        |   204,426.8 ns |   2,267.72 ns |   1,893.65 ns |   204,960.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 128KB        |   214,431.8 ns |   4,109.15 ns |   3,642.66 ns |   213,960.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 128KB        |   242,566.8 ns |   1,987.85 ns |   1,659.94 ns |   242,385.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 128KB        |   450,856.9 ns |   8,441.19 ns |   7,048.78 ns |   448,046.9 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE3 | Native                              | 128B         |       149.0 ns |       3.02 ns |       2.83 ns |       149.6 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 128B         |       381.1 ns |       7.27 ns |       8.08 ns |       380.9 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 128B         |       510.4 ns |       5.53 ns |       4.32 ns |       511.1 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 128B         |       781.5 ns |      13.35 ns |      12.49 ns |       777.4 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE3 | Native                              | 137B         |       207.0 ns |       3.92 ns |       3.48 ns |       206.3 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 137B         |       448.9 ns |       6.61 ns |       5.16 ns |       449.3 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 137B         |       722.3 ns |       8.84 ns |       6.91 ns |       722.4 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 137B         |     1,173.7 ns |      23.41 ns |      23.00 ns |     1,168.6 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE3 | Native                              | 1KB          |       941.9 ns |      11.42 ns |       9.54 ns |       939.8 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 1KB          |     1,423.9 ns |      25.47 ns |      56.44 ns |     1,405.7 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 1KB          |     3,556.5 ns |      55.42 ns |      46.27 ns |     3,549.7 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 1KB          |     6,031.3 ns |      85.97 ns |      71.79 ns |     6,030.6 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE3 | Native                              | 1025B        |     1,088.6 ns |      12.29 ns |      10.90 ns |     1,086.5 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 1025B        |     1,594.0 ns |      25.76 ns |      22.83 ns |     1,591.6 ns |     224 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 1025B        |     4,016.7 ns |      73.67 ns |      65.30 ns |     4,009.8 ns |     224 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 1025B        |     7,155.7 ns |     142.53 ns |     306.81 ns |     7,109.1 ns |     168 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE3 | Native                              | 8KB          |     2,254.3 ns |      42.68 ns |      39.93 ns |     2,238.4 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 8KB          |    11,361.6 ns |      72.15 ns |      63.96 ns |    11,382.2 ns |     896 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 8KB          |    29,755.0 ns |     516.85 ns |     507.62 ns |    29,929.5 ns |     896 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 8KB          |    50,782.8 ns |     985.54 ns |   1,134.95 ns |    50,351.8 ns |     504 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | BLAKE3 | Native                              | 128KB        |    33,797.1 ns |     512.58 ns |     454.38 ns |    33,607.7 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 128KB        |   181,583.0 ns |   2,397.88 ns |   2,242.98 ns |   181,398.2 ns |   14336 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 128KB        |   474,208.2 ns |   6,854.44 ns |   6,076.28 ns |   473,446.6 ns |   14336 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 128KB        |   819,239.8 ns |  10,934.13 ns |  10,227.80 ns |   815,803.7 ns |    7224 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 128B         |       368.3 ns |       3.41 ns |       2.85 ns |       368.1 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 128B         |       411.9 ns |       6.10 ns |      11.01 ns |       408.2 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 128B         |       591.2 ns |       8.60 ns |      12.87 ns |       588.1 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 137B         |       356.6 ns |       6.85 ns |       6.07 ns |       355.6 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 137B         |       420.2 ns |       8.20 ns |      13.92 ns |       416.0 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 137B         |       599.1 ns |       8.26 ns |       7.33 ns |       599.5 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 1KB          |     2,025.4 ns |      39.41 ns |      45.38 ns |     2,016.1 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 1KB          |     2,427.5 ns |      47.23 ns |      44.18 ns |     2,422.3 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 1KB          |     3,497.2 ns |      39.59 ns |      35.10 ns |     3,500.0 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 1025B        |     2,023.9 ns |      36.57 ns |      34.21 ns |     2,024.0 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 1025B        |     2,446.0 ns |      35.40 ns |      33.12 ns |     2,450.7 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 1025B        |     3,477.8 ns |      59.40 ns |      52.66 ns |     3,472.2 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 8KB          |    12,761.1 ns |     129.26 ns |     107.94 ns |    12,791.0 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 8KB          |    16,592.5 ns |     301.11 ns |     295.73 ns |    16,540.7 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 8KB          |    22,754.1 ns |     451.71 ns |     502.08 ns |    22,609.8 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 128KB        |   201,261.2 ns |   1,598.95 ns |   1,417.43 ns |   201,312.5 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 128KB        |   259,059.3 ns |   3,262.66 ns |   2,724.47 ns |   258,492.5 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 128KB        |   358,925.0 ns |   4,780.80 ns |   4,471.97 ns |   359,368.4 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 128B         |       394.9 ns |       5.03 ns |       4.46 ns |       394.7 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 128B         |       433.8 ns |       8.70 ns |      20.34 ns |       430.0 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 128B         |       596.3 ns |      11.26 ns |      11.06 ns |       593.9 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 137B         |       769.5 ns |      12.69 ns |      11.25 ns |       766.7 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 137B         |       771.7 ns |      15.24 ns |      34.09 ns |       759.4 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 137B         |     1,287.7 ns |      25.78 ns |      22.86 ns |     1,290.1 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 1KB          |     2,304.6 ns |      20.57 ns |      17.17 ns |     2,301.3 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 1KB          |     2,867.3 ns |      51.86 ns |      43.31 ns |     2,868.4 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 1KB          |     4,042.5 ns |      80.61 ns |     171.78 ns |     3,983.3 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 1025B        |     2,230.2 ns |      27.22 ns |      25.47 ns |     2,226.1 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 1025B        |     2,756.8 ns |      30.58 ns |      25.54 ns |     2,755.2 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 1025B        |     4,049.0 ns |      80.23 ns |     162.07 ns |     4,009.8 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 8KB          |    16,107.9 ns |     321.60 ns |     450.84 ns |    15,918.7 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 8KB          |    20,389.1 ns |     260.81 ns |     231.20 ns |    20,403.4 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 8KB          |    28,554.2 ns |     403.39 ns |     336.85 ns |    28,530.8 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 128KB        |   245,404.0 ns |   4,477.90 ns |   3,739.25 ns |   243,416.5 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 128KB        |   343,909.2 ns |  10,600.03 ns |  31,088.05 ns |   324,983.0 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 128KB        |   443,805.6 ns |   5,426.80 ns |   4,810.72 ns |   442,530.2 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 128B         |       310.9 ns |       2.29 ns |       2.03 ns |       310.8 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 128B         |       406.6 ns |       4.87 ns |       4.06 ns |       406.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 128B         |       560.7 ns |      17.62 ns |      50.83 ns |       535.5 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 137B         |       669.9 ns |       6.86 ns |       6.08 ns |       670.5 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 137B         |       742.6 ns |       8.14 ns |       7.22 ns |       743.9 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 137B         |     1,110.5 ns |      21.03 ns |      18.65 ns |     1,099.5 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 1KB          |     2,202.0 ns |      38.20 ns |      35.73 ns |     2,197.6 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 1KB          |     2,775.9 ns |      55.31 ns |      46.19 ns |     2,756.7 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 1KB          |     3,809.9 ns |      71.06 ns |      63.00 ns |     3,809.1 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 1025B        |     2,201.2 ns |      43.94 ns |      74.61 ns |     2,184.9 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 1025B        |     2,837.8 ns |      53.81 ns |      57.58 ns |     2,829.9 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 1025B        |     3,824.7 ns |      64.68 ns |      57.34 ns |     3,804.5 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 8KB          |    16,096.5 ns |     329.02 ns |     883.88 ns |    15,779.5 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 8KB          |    22,011.0 ns |     672.58 ns |   1,885.98 ns |    21,083.2 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 8KB          |    28,129.1 ns |     436.98 ns |     408.75 ns |    28,013.9 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 128KB        |   248,032.2 ns |   4,869.07 ns |   4,782.08 ns |   247,076.4 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 128KB        |   323,255.7 ns |   5,133.21 ns |   5,911.41 ns |   321,491.0 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 128KB        |   453,759.5 ns |   8,930.42 ns |  10,967.36 ns |   450,834.4 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **128B**         |     **1,072.4 ns** |      **15.02 ns** |      **12.54 ns** |     **1,066.1 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                         | **128B**         |     **1,612.0 ns** |      **30.27 ns** |      **31.09 ns** |     **1,598.6 ns** |     **296 B** |
| ComputeHash | KMAC-128 | BouncyCastle                      | 128B         |     2,448.9 ns |      47.57 ns |      72.65 ns |     2,424.8 ns |     400 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **137B**         |     **1,086.8 ns** |      **17.57 ns** |      **15.58 ns** |     **1,089.2 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                         | **137B**         |     **1,652.2 ns** |      **23.19 ns** |      **18.11 ns** |     **1,653.8 ns** |     **312 B** |
| ComputeHash | KMAC-128 | BouncyCastle                      | 137B         |     2,384.0 ns |      43.98 ns |      92.76 ns |     2,357.4 ns |     400 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **1KB**          |     **2,674.3 ns** |      **25.74 ns** |      **21.49 ns** |     **2,676.1 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                         | **1KB**          |     **3,759.8 ns** |      **30.25 ns** |      **26.81 ns** |     **3,759.4 ns** |    **1192 B** |
| ComputeHash | KMAC-128 | BouncyCastle                      | 1KB          |     4,348.2 ns |      61.36 ns |      54.40 ns |     4,345.9 ns |     400 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **1025B**        |     **2,706.5 ns** |      **54.08 ns** |      **45.16 ns** |     **2,691.7 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                         | **1025B**        |     **3,826.1 ns** |      **73.64 ns** |     **114.65 ns** |     **3,788.0 ns** |    **1200 B** |
| ComputeHash | KMAC-128 | BouncyCastle                      | 1025B        |     4,349.8 ns |      73.92 ns |      69.14 ns |     4,335.9 ns |     400 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **8KB**          |    **13,598.8 ns** |     **235.33 ns** |     **241.67 ns** |    **13,562.5 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | BouncyCastle**                      | **8KB**          |    **18,439.7 ns** |     **185.10 ns** |     **164.08 ns** |    **18,416.9 ns** |     **400 B** |
| ComputeHash | KMAC-128 | OS Native                         | 8KB          |    18,869.1 ns |     256.76 ns |     227.61 ns |    18,869.4 ns |    8360 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **128KB**        |   **202,330.2 ns** |   **1,929.85 ns** |   **1,506.70 ns** |   **202,374.6 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | BouncyCastle**                      | **128KB**        |   **270,145.8 ns** |   **4,420.11 ns** |  **10,759.17 ns** |   **266,665.6 ns** |     **400 B** |
| ComputeHash | KMAC-128 | OS Native                         | 128KB        |   341,586.0 ns |   6,656.63 ns |   6,226.61 ns |   340,740.1 ns |  131264 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **128B**         |     **1,064.0 ns** |      **20.02 ns** |      **21.42 ns** |     **1,058.1 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **128B**         |     **1,589.0 ns** |      **29.61 ns** |      **27.69 ns** |     **1,583.6 ns** |     **360 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 128B         |     2,268.7 ns |      28.05 ns |      24.86 ns |     2,268.2 ns |     464 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **137B**         |     **1,401.1 ns** |      **26.29 ns** |      **21.95 ns** |     **1,403.7 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **137B**         |     **1,957.1 ns** |      **38.29 ns** |      **37.61 ns** |     **1,960.2 ns** |     **376 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 137B         |     2,615.8 ns |      31.77 ns |      28.17 ns |     2,613.1 ns |     464 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **1KB**          |     **2,932.6 ns** |      **50.89 ns** |      **47.60 ns** |     **2,935.2 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **1KB**          |     **4,079.9 ns** |      **52.10 ns** |      **48.73 ns** |     **4,091.7 ns** |    **1256 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 1KB          |     4,711.4 ns |      90.04 ns |      96.35 ns |     4,720.6 ns |     464 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **1025B**        |     **2,928.6 ns** |      **35.71 ns** |      **31.66 ns** |     **2,928.0 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **1025B**        |     **4,101.6 ns** |      **64.70 ns** |      **54.03 ns** |     **4,107.7 ns** |    **1264 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 1025B        |     4,766.0 ns |      87.89 ns |      86.32 ns |     4,733.5 ns |     464 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **8KB**          |    **16,483.6 ns** |     **150.69 ns** |     **125.83 ns** |    **16,515.9 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **8KB**          |    **22,939.7 ns** |     **318.03 ns** |     **281.93 ns** |    **22,882.1 ns** |    **8424 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 8KB          |    24,627.6 ns |     815.41 ns |   2,313.19 ns |    23,708.5 ns |     464 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **128KB**        |   **248,911.2 ns** |   **4,802.63 ns** |   **4,010.41 ns** |   **248,718.8 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | BouncyCastle**                      | **128KB**        |   **325,792.1 ns** |   **4,976.28 ns** |   **4,411.34 ns** |   **325,888.6 ns** |     **464 B** |
| ComputeHash | KMAC-256 | OS Native                         | 128KB        |   410,348.4 ns |   8,000.35 ns |  11,726.81 ns |   406,690.4 ns |  131327 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 128B         |       330.8 ns |       6.67 ns |      11.86 ns |       326.4 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 128B         |       423.2 ns |       5.56 ns |       4.34 ns |       422.8 ns |     584 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 137B         |       325.7 ns |       6.05 ns |      14.83 ns |       320.1 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 137B         |       454.7 ns |       7.29 ns |      10.22 ns |       452.7 ns |     584 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 1KB          |     1,267.1 ns |      25.18 ns |      23.55 ns |     1,266.0 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 1KB          |     1,991.9 ns |      33.15 ns |      27.68 ns |     1,998.9 ns |     584 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 1025B        |     1,256.1 ns |      16.70 ns |      13.94 ns |     1,258.7 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 1025B        |     1,987.8 ns |      27.78 ns |      23.20 ns |     1,985.0 ns |     584 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 8KB          |     8,068.0 ns |     152.71 ns |     142.84 ns |     8,026.6 ns |    1056 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 8KB          |    13,501.3 ns |     187.48 ns |     156.56 ns |    13,479.7 ns |    1056 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 128KB        |   117,281.6 ns |   1,642.06 ns |   1,371.20 ns |   117,125.7 ns |    8136 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 128KB        |   199,820.8 ns |   3,319.99 ns |   3,260.68 ns |   198,894.6 ns |    8136 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 128B         |       352.2 ns |       4.09 ns |       3.42 ns |       353.7 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 128B         |       466.8 ns |       9.04 ns |       7.55 ns |       467.7 ns |     616 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 137B         |       578.0 ns |       6.24 ns |       5.53 ns |       581.0 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 137B         |       901.8 ns |      10.90 ns |       9.10 ns |       898.8 ns |     616 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 1KB          |     1,370.4 ns |      23.04 ns |      17.99 ns |     1,363.9 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 1KB          |     2,316.6 ns |      45.40 ns |      50.46 ns |     2,300.7 ns |     616 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 1025B        |     1,377.0 ns |      25.24 ns |      22.37 ns |     1,376.0 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 1025B        |     2,268.0 ns |      37.05 ns |      32.85 ns |     2,271.1 ns |     616 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 8KB          |     9,446.2 ns |     156.13 ns |     153.34 ns |     9,432.4 ns |    1056 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 8KB          |    16,040.9 ns |     291.22 ns |     243.18 ns |    15,995.4 ns |    1056 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 128KB        |   149,785.2 ns |   1,941.26 ns |   1,720.88 ns |   149,208.0 ns |    7656 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 128KB        |   248,925.5 ns |   4,567.44 ns |   3,814.02 ns |   248,028.3 ns |    7656 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | MD5 | BouncyCastle                           | 128B         |       370.9 ns |       5.98 ns |       5.30 ns |       369.9 ns |      80 B |
| ComputeHash | MD5 | OS Native                              | 128B         |       421.7 ns |       7.34 ns |       6.13 ns |       420.3 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **128B**         |       **527.9 ns** |      **10.57 ns** |       **9.37 ns** |       **527.4 ns** |      **80 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | MD5 | BouncyCastle**                           | **137B**         |       **367.1 ns** |       **7.13 ns** |       **6.67 ns** |       **365.2 ns** |      **80 B** |
| ComputeHash | MD5 | OS Native                              | 137B         |       418.7 ns |       7.22 ns |       7.10 ns |       416.2 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **137B**         |       **542.7 ns** |       **6.52 ns** |       **5.78 ns** |       **543.3 ns** |      **80 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | MD5 | BouncyCastle**                           | **1KB**          |     **1,761.0 ns** |      **27.94 ns** |      **24.77 ns** |     **1,754.0 ns** |      **80 B** |
| ComputeHash | MD5 | OS Native                              | 1KB          |     1,839.1 ns |      16.04 ns |      14.22 ns |     1,840.5 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **1KB**          |     **2,891.0 ns** |      **56.64 ns** |      **52.98 ns** |     **2,888.0 ns** |      **80 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | MD5 | BouncyCastle**                           | **1025B**        |     **1,796.8 ns** |      **29.44 ns** |      **27.54 ns** |     **1,785.5 ns** |      **80 B** |
| ComputeHash | MD5 | OS Native                              | 1025B        |     1,844.2 ns |      14.56 ns |      12.16 ns |     1,845.1 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **1025B**        |     **2,928.6 ns** |      **58.39 ns** |      **97.55 ns** |     **2,901.6 ns** |      **80 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | MD5 | BouncyCastle**                           | **8KB**          |    **12,866.0 ns** |     **211.56 ns** |     **259.82 ns** |    **12,835.0 ns** |      **80 B** |
| ComputeHash | MD5 | OS Native                              | 8KB          |    13,457.1 ns |     252.40 ns |     236.09 ns |    13,383.4 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **8KB**          |    **20,871.0 ns** |     **272.74 ns** |     **241.77 ns** |    **20,878.4 ns** |      **80 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | MD5 | BouncyCastle**                           | **128KB**        |   **207,632.0 ns** |   **2,103.20 ns** |   **1,756.27 ns** |   **207,774.7 ns** |      **80 B** |
| ComputeHash | MD5 | OS Native                              | 128KB        |   209,932.3 ns |   2,836.48 ns |   2,214.54 ns |   209,804.9 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **128KB**        |   **331,619.5 ns** |   **3,184.58 ns** |   **2,659.27 ns** |   **332,026.3 ns** |      **80 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **128B**         |       **585.6 ns** |      **11.13 ns** |       **9.29 ns** |       **585.8 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **128B**         |     **1,502.3 ns** |      **29.78 ns** |      **30.58 ns** |     **1,485.3 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **137B**         |       **569.4 ns** |      **11.47 ns** |      **13.21 ns** |       **566.0 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **137B**         |     **1,530.3 ns** |      **29.62 ns** |      **29.09 ns** |     **1,516.0 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **1KB**          |     **2,921.0 ns** |      **49.09 ns** |      **43.52 ns** |     **2,908.9 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **1KB**          |     **8,257.9 ns** |     **116.48 ns** |      **97.27 ns** |     **8,239.1 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **1025B**        |     **2,918.9 ns** |      **47.76 ns** |      **44.67 ns** |     **2,906.2 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **1025B**        |     **8,239.8 ns** |     **142.07 ns** |     **132.89 ns** |     **8,237.8 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **8KB**          |    **21,612.1 ns** |     **344.26 ns** |     **322.02 ns** |    **21,601.1 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **8KB**          |    **61,334.2 ns** |     **761.02 ns** |     **594.15 ns** |    **61,342.7 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **128KB**        |   **335,960.7 ns** |   **2,168.34 ns** |   **1,922.18 ns** |   **336,005.5 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **128KB**        |   **970,463.0 ns** |  **14,598.03 ns** |  **13,655.00 ns** |   **968,740.2 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-1 | OS Native**                            | **128B**         |       **387.0 ns** |       **5.03 ns** |       **4.71 ns** |       **386.1 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 128B         |       577.6 ns |      11.08 ns |      11.37 ns |       575.4 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **128B**         |       **625.6 ns** |      **12.58 ns** |      **19.21 ns** |       **621.9 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-1 | OS Native**                            | **137B**         |       **389.2 ns** |       **7.77 ns** |       **8.95 ns** |       **386.1 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 137B         |       592.6 ns |      11.08 ns |       9.82 ns |       593.9 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **137B**         |       **620.5 ns** |       **9.60 ns** |      **17.55 ns** |       **613.8 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-1 | OS Native**                            | **1KB**          |     **1,625.1 ns** |      **19.26 ns** |      **16.08 ns** |     **1,628.5 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 1KB          |     2,986.1 ns |      59.74 ns |      61.35 ns |     2,955.4 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **1KB**          |     **3,039.7 ns** |      **29.67 ns** |      **24.78 ns** |     **3,042.1 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-1 | OS Native**                            | **1025B**        |     **1,638.9 ns** |      **19.82 ns** |      **17.57 ns** |     **1,635.7 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 1025B        |     2,958.5 ns |      28.79 ns |      22.48 ns |     2,953.0 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **1025B**        |     **3,091.8 ns** |      **30.10 ns** |      **25.13 ns** |     **3,091.6 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-1 | OS Native**                            | **8KB**          |    **11,621.4 ns** |     **119.18 ns** |     **105.65 ns** |    **11,610.2 ns** |      **96 B** |
| **ComputeHash | SHA-1 | CryptoHives**                          | **8KB**          |    **21,824.1 ns** |     **416.17 ns** |     **408.73 ns** |    **21,759.5 ns** |      **96 B** |
| **ComputeHash | SHA-1 | BouncyCastle**                         | **8KB**          |    **21,880.4 ns** |     **248.13 ns** |     **219.96 ns** |    **21,885.3 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA-1 | OS Native                            | 128KB        |   183,389.2 ns |   1,611.91 ns |   1,346.01 ns |   183,318.9 ns |      96 B |
| ComputeHash | SHA-1 | BouncyCastle                         | 128KB        |   347,303.0 ns |   6,832.97 ns |   6,391.56 ns |   345,141.2 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **128KB**        |   **364,834.8 ns** |   **4,771.17 ns** |   **4,229.52 ns** |   **364,612.1 ns** |      **96 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **128B**         |       **838.8 ns** |      **11.77 ns** |      **10.43 ns** |       **841.0 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **128B**         |       **871.2 ns** |      **14.48 ns** |      **16.68 ns** |       **870.7 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **137B**         |       **851.0 ns** |       **8.52 ns** |       **7.55 ns** |       **850.7 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **137B**         |       **919.9 ns** |      **18.07 ns** |      **27.05 ns** |       **911.8 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **1KB**          |     **4,412.7 ns** |      **76.33 ns** |     **154.18 ns** |     **4,363.6 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **1KB**          |     **4,453.2 ns** |      **85.68 ns** |      **84.15 ns** |     **4,442.7 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **1025B**        |     **4,387.8 ns** |      **84.30 ns** |     **106.61 ns** |     **4,362.4 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **1025B**        |     **4,405.2 ns** |      **66.20 ns** |      **58.69 ns** |     **4,397.2 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **8KB**          |    **33,467.7 ns** |     **371.99 ns** |     **329.76 ns** |    **33,528.3 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **8KB**          |    **34,259.0 ns** |     **663.34 ns** |     **992.85 ns** |    **34,083.5 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **128KB**        |   **526,024.0 ns** |   **6,237.17 ns** |   **5,208.32 ns** |   **526,317.9 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **128KB**        |   **540,323.6 ns** |   **5,987.40 ns** |   **5,307.67 ns** |   **540,725.5 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-256 | OS Native**                          | **128B**         |       **209.9 ns** |       **2.11 ns** |       **1.76 ns** |       **209.4 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 128B         |       817.8 ns |       7.81 ns |       6.52 ns |       819.2 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **128B**         |       **908.8 ns** |      **16.16 ns** |      **14.32 ns** |       **903.0 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-256 | OS Native**                          | **137B**         |       **211.8 ns** |       **4.20 ns** |       **4.31 ns** |       **210.6 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 137B         |       820.8 ns |       6.64 ns |       5.54 ns |       820.1 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **137B**         |       **885.3 ns** |      **10.77 ns** |       **9.54 ns** |       **883.3 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-256 | OS Native**                          | **1KB**          |       **685.3 ns** |      **12.82 ns** |      **10.71 ns** |       **681.5 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 1KB          |     4,360.4 ns |      54.64 ns |      45.62 ns |     4,368.6 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **1KB**          |     **4,415.5 ns** |      **61.23 ns** |      **54.28 ns** |     **4,415.8 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-256 | OS Native**                          | **1025B**        |       **685.1 ns** |      **10.72 ns** |       **9.51 ns** |       **683.8 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 1025B        |     4,353.1 ns |      38.45 ns |      34.08 ns |     4,344.7 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **1025B**        |     **4,456.5 ns** |      **80.58 ns** |      **82.75 ns** |     **4,447.8 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-256 | OS Native**                          | **8KB**          |     **4,401.1 ns** |      **51.13 ns** |      **45.33 ns** |     **4,393.0 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 8KB          |    32,093.1 ns |     560.81 ns |     437.84 ns |    31,968.7 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **8KB**          |    **32,848.8 ns** |     **460.61 ns** |     **430.85 ns** |    **32,751.9 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-256 | OS Native**                          | **128KB**        |    **69,029.3 ns** |   **1,297.07 ns** |   **1,213.28 ns** |    **68,583.7 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 128KB        |   513,647.7 ns |  10,085.86 ns |   8,940.86 ns |   510,837.3 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **128KB**        |   **523,839.2 ns** |   **8,373.79 ns** |   **7,423.15 ns** |   **523,724.2 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-384 | OS Native**                          | **128B**         |       **575.7 ns** |       **3.78 ns** |       **3.35 ns** |       **576.9 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 128B         |       743.3 ns |       7.25 ns |       6.06 ns |       741.5 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **128B**         |       **857.9 ns** |      **17.12 ns** |      **21.02 ns** |       **850.7 ns** |     **144 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-384 | OS Native**                          | **137B**         |       **585.8 ns** |      **10.78 ns** |      **10.59 ns** |       **583.6 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 137B         |       738.9 ns |       9.26 ns |       7.73 ns |       740.5 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **137B**         |       **818.7 ns** |       **9.43 ns** |       **7.87 ns** |       **817.5 ns** |     **144 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-384 | OS Native**                          | **1KB**          |     **2,143.4 ns** |      **34.81 ns** |      **44.02 ns** |     **2,128.6 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 1KB          |     3,161.6 ns |      62.49 ns |      58.45 ns |     3,167.1 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **1KB**          |     **3,172.5 ns** |      **55.06 ns** |      **67.62 ns** |     **3,155.0 ns** |     **144 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-384 | OS Native**                          | **1025B**        |     **2,112.1 ns** |      **33.45 ns** |      **29.66 ns** |     **2,109.8 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 1025B        |     3,245.7 ns |      64.86 ns |     118.60 ns |     3,213.1 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **1025B**        |     **3,307.6 ns** |      **79.18 ns** |     **224.61 ns** |     **3,194.3 ns** |     **144 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-384 | OS Native**                          | **8KB**          |    **14,139.4 ns** |     **137.78 ns** |     **122.14 ns** |    **14,110.8 ns** |     **144 B** |
| **ComputeHash | SHA-384 | CryptoHives**                        | **8KB**          |    **21,646.6 ns** |     **401.11 ns** |     **313.16 ns** |    **21,641.6 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                       | **8KB**          |    **22,096.6 ns** |     **287.16 ns** |     **239.80 ns** |    **22,106.0 ns** |     **144 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA-384 | OS Native                          | 128KB        |   220,879.5 ns |   2,079.93 ns |   1,843.80 ns |   221,124.7 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **128KB**        |   **349,107.9 ns** |   **6,769.39 ns** |   **9,266.02 ns** |   **348,468.1 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                       | **128KB**        |   **353,756.0 ns** |   **5,142.98 ns** |   **4,015.30 ns** |   **354,747.6 ns** |     **144 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA-512 | OS Native                          | 128B         |       588.5 ns |       5.29 ns |       4.69 ns |       586.7 ns |     176 B |
| ComputeHash | SHA-512 | BouncyCastle                       | 128B         |       745.6 ns |      13.36 ns |      11.84 ns |       746.1 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **128B**         |       **922.7 ns** |      **18.33 ns** |      **29.07 ns** |       **913.6 ns** |     **176 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512 | OS Native**                          | **137B**         |       **579.1 ns** |      **10.38 ns** |       **9.20 ns** |       **579.8 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 137B         |       752.2 ns |       7.68 ns |       6.41 ns |       753.0 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **137B**         |       **836.6 ns** |      **12.49 ns** |      **11.68 ns** |       **835.2 ns** |     **176 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512 | OS Native**                          | **1KB**          |     **2,111.3 ns** |      **28.30 ns** |      **25.09 ns** |     **2,111.5 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 1KB          |     3,152.7 ns |      55.85 ns |      49.51 ns |     3,146.3 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **1KB**          |     **3,238.1 ns** |      **40.90 ns** |      **34.15 ns** |     **3,223.7 ns** |     **176 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512 | OS Native**                          | **1025B**        |     **2,159.6 ns** |      **42.68 ns** |      **94.57 ns** |     **2,121.9 ns** |     **176 B** |
| **ComputeHash | SHA-512 | CryptoHives**                        | **1025B**        |     **3,237.3 ns** |      **29.88 ns** |      **23.33 ns** |     **3,233.6 ns** |     **176 B** |
| **ComputeHash | SHA-512 | BouncyCastle**                       | **1025B**        |     **3,587.0 ns** |     **215.28 ns** |     **627.97 ns** |     **3,197.8 ns** |     **176 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA-512 | OS Native                          | 8KB          |    14,361.3 ns |     271.73 ns |     279.05 ns |    14,304.4 ns |     176 B |
| ComputeHash | SHA-512 | BouncyCastle                       | 8KB          |    21,899.2 ns |     413.05 ns |     344.91 ns |    21,860.1 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **8KB**          |    **22,219.2 ns** |     **340.10 ns** |     **301.49 ns** |    **22,201.1 ns** |     **176 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512 | OS Native**                          | **128KB**        |   **221,500.5 ns** |   **1,982.25 ns** |   **1,655.27 ns** |   **221,082.2 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 128KB        |   345,680.5 ns |   5,440.63 ns |   4,822.98 ns |   343,803.9 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **128KB**        |   **346,701.4 ns** |   **3,980.76 ns** |   **3,324.12 ns** |   **345,727.1 ns** |     **176 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **128B**         |       **760.3 ns** |      **15.14 ns** |      **13.42 ns** |       **756.9 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **128B**         |       **856.9 ns** |       **7.33 ns** |       **6.12 ns** |       **857.3 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **137B**         |       **753.1 ns** |       **9.16 ns** |       **8.12 ns** |       **751.9 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **137B**         |       **807.8 ns** |      **15.52 ns** |      **14.52 ns** |       **800.9 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **1KB**          |     **3,137.2 ns** |      **60.49 ns** |      **59.41 ns** |     **3,121.3 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **1KB**          |     **3,140.3 ns** |      **32.06 ns** |      **28.42 ns** |     **3,139.9 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA-512/224 | CryptoHives                    | 1025B        |     3,140.0 ns |      46.46 ns |      38.80 ns |     3,133.0 ns |     112 B |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **1025B**        |     **3,883.7 ns** |     **156.44 ns** |     **448.87 ns** |     **3,864.2 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA-512/224 | BouncyCastle                   | 8KB          |    27,190.2 ns |     538.76 ns |   1,280.42 ns |    27,290.0 ns |     112 B |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **8KB**          |    **30,975.7 ns** |   **1,851.29 ns** |   **5,429.53 ns** |    **28,513.1 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **128KB**        |   **422,000.0 ns** |   **8,425.88 ns** |  **23,765.34 ns** |   **429,839.5 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **128KB**        |   **430,194.8 ns** |   **9,642.07 ns** |  **25,231.62 ns** |   **433,791.1 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **128B**         |       **938.6 ns** |      **18.56 ns** |      **32.51 ns** |       **944.4 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **128B**         |     **1,017.0 ns** |      **21.16 ns** |      **61.04 ns** |     **1,030.8 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **137B**         |       **939.5 ns** |      **18.61 ns** |      **40.45 ns** |       **947.6 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **137B**         |     **1,032.5 ns** |      **20.45 ns** |      **37.39 ns** |     **1,034.8 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA-512/256 | CryptoHives                    | 1KB          |     3,943.0 ns |      77.75 ns |     184.78 ns |     3,967.8 ns |     112 B |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **1KB**          |     **3,995.6 ns** |     **104.23 ns** |     **297.38 ns** |     **3,952.4 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA-512/256 | BouncyCastle                   | 1025B        |     3,888.3 ns |      77.61 ns |     171.98 ns |     3,923.8 ns |     112 B |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **1025B**        |     **3,969.4 ns** |      **79.02 ns** |     **176.75 ns** |     **4,005.8 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **8KB**          |    **26,925.6 ns** |     **532.93 ns** |   **1,191.98 ns** |    **27,149.5 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **8KB**          |    **27,836.1 ns** |     **549.20 ns** |   **1,205.52 ns** |    **27,838.5 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **128KB**        |   **421,663.1 ns** |   **8,337.45 ns** |  **19,976.00 ns** |   **423,948.2 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **128KB**        |   **429,826.1 ns** |   **8,592.02 ns** |  **23,081.92 ns** |   **438,619.2 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar**           | **128B**         |       **441.3 ns** |       **8.86 ns** |      **24.99 ns** |       **446.7 ns** |     **112 B** |
| ComputeHash | SHA3-224 | BouncyCastle                      | 128B         |       619.3 ns |      12.08 ns |      33.67 ns |       621.2 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 128B         |     1,149.8 ns |      64.08 ns |     188.94 ns |     1,155.2 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 137B         |       436.7 ns |       8.77 ns |      12.85 ns |       433.7 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 137B         |       631.5 ns |      17.64 ns |      51.45 ns |       633.6 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 137B         |     1,282.0 ns |      90.50 ns |     263.98 ns |     1,291.1 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 1KB          |     3,059.4 ns |      61.07 ns |     175.21 ns |     3,090.9 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 1KB          |     4,111.7 ns |     111.40 ns |     324.95 ns |     4,135.9 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 1KB          |     8,670.7 ns |     568.35 ns |   1,675.78 ns |     9,155.4 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 1025B        |     3,191.4 ns |      92.16 ns |     270.28 ns |     3,140.5 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 1025B        |     4,769.2 ns |     354.67 ns |   1,034.58 ns |     4,343.3 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 1025B        |     8,388.5 ns |     454.31 ns |   1,318.03 ns |     8,354.1 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 8KB          |    20,029.8 ns |     399.17 ns |   1,016.01 ns |    20,145.7 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 8KB          |    29,200.7 ns |     874.92 ns |   2,538.30 ns |    29,505.8 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 8KB          |    58,421.3 ns |   2,999.43 ns |   8,843.88 ns |    58,724.3 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 128KB        |   319,815.3 ns |   7,985.58 ns |  23,420.31 ns |   324,359.7 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 128KB        |   474,033.0 ns |  13,003.84 ns |  35,597.81 ns |   475,795.6 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 128KB        |   937,429.1 ns |  43,450.46 ns | 127,432.70 ns |   933,775.5 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 128B         |       429.8 ns |       8.63 ns |      23.92 ns |       433.9 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 128B         |       614.8 ns |      12.74 ns |      37.18 ns |       619.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 128B         |       624.8 ns |      13.19 ns |      37.21 ns |       626.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 128B         |     1,117.1 ns |      70.40 ns |     207.58 ns |     1,112.6 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 137B         |       929.2 ns |      19.20 ns |      55.10 ns |       934.3 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 137B         |     1,066.9 ns |      21.35 ns |      58.79 ns |     1,078.5 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 137B         |     1,141.1 ns |      27.54 ns |      80.76 ns |     1,141.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 137B         |     2,658.2 ns |     221.63 ns |     650.00 ns |     2,562.5 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 1KB          |     3,006.6 ns |      59.39 ns |     145.68 ns |     3,033.2 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 1KB          |     3,930.7 ns |      78.32 ns |     210.41 ns |     3,961.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 1KB          |     4,224.6 ns |      89.50 ns |     255.36 ns |     4,275.3 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 1KB          |     8,188.3 ns |     607.76 ns |   1,782.47 ns |     8,516.3 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 1025B        |     3,030.1 ns |      62.59 ns |     172.39 ns |     3,063.3 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 1025B        |     3,848.3 ns |      76.80 ns |     196.86 ns |     3,880.1 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 1025B        |     4,698.7 ns |     116.73 ns |     338.66 ns |     4,701.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 1025B        |     8,551.0 ns |     420.08 ns |   1,212.03 ns |     8,569.5 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 8KB          |    21,488.1 ns |     544.48 ns |   1,570.95 ns |    21,913.0 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 8KB          |    30,507.1 ns |     881.65 ns |   2,585.74 ns |    30,743.6 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 8KB          |    35,543.7 ns |   1,680.53 ns |   4,955.09 ns |    33,730.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 8KB          |    67,192.8 ns |   4,022.28 ns |  11,859.79 ns |    67,670.8 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 128KB        |   349,663.5 ns |   7,011.90 ns |  20,342.80 ns |   353,870.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 128KB        |   451,671.7 ns |  10,544.52 ns |  29,393.90 ns |   454,110.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 128KB        |   508,720.4 ns |  18,329.60 ns |  51,398.16 ns |   517,930.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 128KB        |   992,046.1 ns |  59,235.72 ns | 172,793.40 ns |   976,698.1 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 128B         |       855.9 ns |      18.44 ns |      53.79 ns |       858.0 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 128B         |     1,104.9 ns |      24.37 ns |      71.08 ns |     1,105.7 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 128B         |     1,146.7 ns |      51.11 ns |     149.89 ns |     1,102.4 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 128B         |     2,255.7 ns |     130.78 ns |     381.48 ns |     2,226.5 ns |     144 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 137B         |       867.8 ns |      18.92 ns |      53.05 ns |       869.9 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 137B         |     1,084.8 ns |      21.64 ns |      48.85 ns |     1,090.9 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 137B         |     1,130.8 ns |      24.81 ns |      70.80 ns |     1,132.0 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 137B         |     2,260.8 ns |     107.24 ns |     311.13 ns |     2,247.6 ns |     144 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 1KB          |     3,611.9 ns |      73.61 ns |     214.74 ns |     3,652.2 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 1KB          |     4,761.8 ns |      94.78 ns |     254.61 ns |     4,774.7 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 1KB          |     5,173.3 ns |     126.01 ns |     359.52 ns |     5,217.6 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 1KB          |    10,342.0 ns |     556.06 ns |   1,639.56 ns |    10,581.8 ns |     144 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 1025B        |     3,661.1 ns |      72.64 ns |     176.82 ns |     3,702.1 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 1025B        |     4,895.3 ns |      97.46 ns |     253.30 ns |     4,895.8 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 1025B        |     5,046.6 ns |     125.84 ns |     361.05 ns |     5,040.3 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 1025B        |    10,559.5 ns |     554.55 ns |   1,626.41 ns |    10,624.8 ns |     144 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 8KB          |    27,791.3 ns |     554.58 ns |   1,582.25 ns |    28,115.5 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 8KB          |    36,997.1 ns |     692.43 ns |   1,248.60 ns |    37,274.6 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 8KB          |    40,386.3 ns |     997.54 ns |   2,846.04 ns |    40,488.3 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 8KB          |    89,859.6 ns |   6,371.48 ns |  18,585.91 ns |    88,007.3 ns |     144 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 128KB        |   438,206.1 ns |  10,018.73 ns |  27,426.13 ns |   444,220.4 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 128KB        |   598,074.1 ns |  12,792.19 ns |  36,080.61 ns |   598,795.3 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 128KB        |   633,231.8 ns |  14,350.57 ns |  40,943.00 ns |   636,256.6 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 128KB        | 1,281,283.8 ns |  72,921.96 ns | 212,716.80 ns | 1,297,917.2 ns |     144 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 128B         |       899.8 ns |      43.54 ns |     124.23 ns |       866.2 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 128B         |     1,106.4 ns |      22.03 ns |      41.92 ns |     1,114.0 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 128B         |     1,108.2 ns |      25.77 ns |      73.11 ns |     1,115.0 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 128B         |     2,255.6 ns |     130.16 ns |     375.56 ns |     2,288.7 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 137B         |       780.4 ns |      16.03 ns |      45.47 ns |       787.1 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 137B         |     1,122.4 ns |      28.55 ns |      82.37 ns |     1,123.7 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 137B         |     1,122.8 ns |      21.85 ns |      53.18 ns |     1,124.6 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 137B         |     2,157.4 ns |     133.96 ns |     394.98 ns |     2,186.3 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 1KB          |     5,511.5 ns |     124.77 ns |     349.87 ns |     5,597.6 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 1KB          |     6,995.2 ns |     139.35 ns |     349.61 ns |     6,975.0 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 1KB          |     7,674.2 ns |     259.25 ns |     748.00 ns |     7,670.6 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 1KB          |    14,911.2 ns |     685.02 ns |   2,019.79 ns |    14,754.0 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 1025B        |     5,342.7 ns |     120.94 ns |     352.78 ns |     5,389.7 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 1025B        |     7,066.6 ns |     161.81 ns |     456.39 ns |     7,126.8 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 1025B        |     7,499.1 ns |     250.29 ns |     730.10 ns |     7,528.1 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 1025B        |    15,257.6 ns |     806.09 ns |   2,364.13 ns |    15,545.2 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 8KB          |    40,135.3 ns |     798.05 ns |   2,276.88 ns |    40,136.1 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 8KB          |    52,345.8 ns |   1,308.18 ns |   3,536.74 ns |    52,846.7 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 8KB          |    55,929.7 ns |   1,633.14 ns |   4,763.94 ns |    56,619.9 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 8KB          |   118,280.2 ns |   6,257.07 ns |  18,252.16 ns |   117,287.0 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 128KB        |   631,671.9 ns |  12,576.51 ns |  25,405.18 ns |   633,228.7 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 128KB        |   819,916.6 ns |  18,698.00 ns |  53,648.08 ns |   823,162.2 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 128KB        |   912,214.4 ns |  24,667.34 ns |  69,977.14 ns |   925,345.3 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 128KB        | 1,868,086.8 ns |  97,779.85 ns | 288,306.10 ns | 1,889,905.2 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 128B         |       514.8 ns |      10.59 ns |      30.22 ns |       522.4 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 128B         |       618.7 ns |      13.82 ns |      40.76 ns |       622.3 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 128B         |       781.4 ns |      18.74 ns |      50.34 ns |       779.4 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 128B         |     1,232.7 ns |      60.95 ns |     177.78 ns |     1,230.8 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 137B         |       505.9 ns |      11.16 ns |      31.66 ns |       506.3 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 137B         |       635.4 ns |      18.11 ns |      51.67 ns |       644.4 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 137B         |       765.1 ns |      16.18 ns |      47.20 ns |       778.0 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 137B         |     1,197.2 ns |      55.49 ns |     162.75 ns |     1,175.4 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 1KB          |     2,783.8 ns |      55.55 ns |     152.07 ns |     2,814.4 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 1KB          |     3,614.8 ns |      95.73 ns |     265.26 ns |     3,585.1 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 1KB          |     3,761.4 ns |     122.11 ns |     332.20 ns |     3,780.0 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 1KB          |     7,624.1 ns |     356.13 ns |   1,050.06 ns |     7,761.9 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 1025B        |     2,798.4 ns |      64.94 ns |     189.43 ns |     2,813.8 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 1025B        |     3,697.4 ns |     115.09 ns |     320.83 ns |     3,707.7 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 1025B        |     4,055.6 ns |     228.75 ns |     674.46 ns |     3,840.4 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 1025B        |     7,175.6 ns |     378.65 ns |   1,116.46 ns |     7,139.7 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 8KB          |    17,664.8 ns |     351.87 ns |     908.28 ns |    17,889.5 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 8KB          |    23,443.2 ns |     646.59 ns |   1,791.70 ns |    23,568.0 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 8KB          |    25,569.2 ns |     674.55 ns |   1,978.34 ns |    25,685.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 8KB          |    50,329.4 ns |   2,560.13 ns |   7,508.43 ns |    49,997.2 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 128KB        |   285,605.3 ns |   7,785.50 ns |  21,702.87 ns |   285,558.6 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 128KB        |   366,902.3 ns |   9,488.20 ns |  27,677.51 ns |   368,935.4 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 128KB        |   404,467.3 ns |  11,298.42 ns |  33,136.30 ns |   414,090.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 128KB        |   774,890.8 ns |  40,320.86 ns | 118,254.11 ns |   768,829.1 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 128B         |       526.2 ns |      10.57 ns |      22.06 ns |       528.6 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 128B         |       618.9 ns |      15.49 ns |      43.95 ns |       628.6 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 128B         |       792.8 ns |      15.88 ns |      41.26 ns |       795.1 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 128B         |     1,262.8 ns |      53.96 ns |     159.10 ns |     1,266.8 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 137B         |     1,050.7 ns |      27.76 ns |      77.83 ns |     1,040.2 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 137B         |     1,158.8 ns |      33.17 ns |      95.17 ns |     1,166.7 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 137B         |     1,220.3 ns |      24.17 ns |      59.28 ns |     1,224.8 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 137B         |     2,507.1 ns |     115.65 ns |     341.00 ns |     2,537.6 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 1KB          |     3,084.3 ns |      62.42 ns |     181.08 ns |     3,120.6 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 1KB          |     4,143.6 ns |      82.24 ns |     188.97 ns |     4,180.7 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 1KB          |     4,217.6 ns |      93.69 ns |     270.30 ns |     4,272.9 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 1KB          |     8,552.0 ns |     478.75 ns |   1,411.61 ns |     8,620.7 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 1025B        |     3,183.8 ns |     102.34 ns |     274.93 ns |     3,154.2 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 1025B        |     4,071.8 ns |      98.22 ns |     270.52 ns |     4,095.8 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 1025B        |     4,282.5 ns |     104.43 ns |     302.98 ns |     4,279.5 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 1025B        |     8,557.9 ns |     500.55 ns |   1,475.89 ns |     8,533.4 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 8KB          |    22,122.3 ns |     496.84 ns |   1,384.98 ns |    22,253.5 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 8KB          |    29,892.1 ns |     596.23 ns |   1,119.87 ns |    29,866.7 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 8KB          |    31,343.3 ns |     743.30 ns |   2,132.65 ns |    31,573.0 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 8KB          |    62,348.5 ns |   2,918.84 ns |   8,560.44 ns |    62,655.1 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 128KB        |   353,028.6 ns |   9,422.96 ns |  26,423.00 ns |   356,777.7 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 128KB        |   452,863.7 ns |   9,021.28 ns |  23,286.81 ns |   453,684.5 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 128KB        |   487,293.4 ns |  17,521.70 ns |  49,132.73 ns |   493,844.1 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 128KB        | 1,003,549.1 ns |  56,635.59 ns | 166,991.33 ns | 1,013,926.2 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SM3 | BouncyCastle                           | 128B         |     1,295.7 ns |      25.79 ns |      71.03 ns |     1,295.5 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                            | **128B**         |     **1,351.0 ns** |      **40.42 ns** |     **114.00 ns** |     **1,357.6 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SM3 | BouncyCastle**                           | **137B**         |     **1,300.7 ns** |      **31.44 ns** |      **91.70 ns** |     **1,300.3 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                            | **137B**         |     **1,304.3 ns** |      **36.59 ns** |     **106.73 ns** |     **1,337.3 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | SM3 | BouncyCastle**                           | **1KB**          |     **6,853.7 ns** |     **223.97 ns** |     **649.79 ns** |     **6,861.1 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                            | **1KB**          |     **6,922.9 ns** |     **174.33 ns** |     **505.75 ns** |     **6,997.7 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SM3 | CryptoHives                            | 1025B        |     7,091.8 ns |     185.98 ns |     533.62 ns |     7,184.9 ns |     112 B |
| **ComputeHash | SM3 | BouncyCastle**                           | **1025B**        |     **7,317.4 ns** |     **352.80 ns** |   **1,023.54 ns** |     **7,231.6 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SM3 | BouncyCastle                           | 8KB          |    52,663.7 ns |   1,337.11 ns |   3,900.42 ns |    53,694.8 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                            | **8KB**          |    **52,995.7 ns** |   **1,246.85 ns** |   **3,637.13 ns** |    **53,495.7 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| ComputeHash | SM3 | CryptoHives                            | 128KB        |   832,600.4 ns |  18,197.60 ns |  53,370.41 ns |   840,348.4 ns |     112 B |
| **ComputeHash | SM3 | BouncyCastle**                           | **128KB**        |   **835,546.4 ns** |  **21,197.25 ns** |  **60,818.88 ns** |   **842,573.7 ns** |     **112 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **128B**         |     **3,408.2 ns** |     **104.93 ns** |     **309.40 ns** |     **3,416.9 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **128B**         |     **5,852.2 ns** |     **137.51 ns** |     **403.30 ns** |     **5,939.5 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 128B         |     7,255.0 ns |     159.31 ns |     464.72 ns |     7,329.1 ns |     200 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **137B**         |     **3,455.0 ns** |      **93.77 ns** |     **264.48 ns** |     **3,464.6 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **137B**         |     **6,042.3 ns** |     **120.63 ns** |     **342.21 ns** |     **6,076.5 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 137B         |     7,413.5 ns |     166.34 ns |     474.58 ns |     7,436.8 ns |     200 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **1KB**          |    **13,079.7 ns** |     **325.77 ns** |     **960.53 ns** |    **13,211.9 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **1KB**          |    **22,163.0 ns** |     **562.39 ns** |   **1,577.00 ns** |    **22,480.6 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 1KB          |    27,957.6 ns |     598.05 ns |   1,753.97 ns |    28,503.9 ns |     200 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **1025B**        |    **12,406.1 ns** |     **359.79 ns** |   **1,060.86 ns** |    **12,612.2 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **1025B**        |    **22,231.7 ns** |     **492.33 ns** |   **1,331.05 ns** |    **22,384.2 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 1025B        |    28,021.5 ns |     600.49 ns |   1,713.23 ns |    28,329.4 ns |     200 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **8KB**          |    **89,555.0 ns** |   **2,864.26 ns** |   **8,445.35 ns** |    **90,257.2 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **8KB**          |   **151,149.3 ns** |   **3,016.11 ns** |   **8,256.56 ns** |   **150,077.9 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 8KB          |   198,707.9 ns |   5,150.35 ns |  14,357.13 ns |   198,186.4 ns |     200 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **128KB**        | **1,405,566.4 ns** |  **34,845.98 ns** |  **95,390.30 ns** | **1,401,948.8 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **128KB**        | **2,596,712.7 ns** | **151,180.66 ns** | **431,326.96 ns** | **2,455,320.0 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 128KB        | 3,076,829.6 ns |  65,637.32 ns | 190,425.78 ns | 3,110,027.7 ns |     200 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **128B**         |     **3,495.3 ns** |     **102.85 ns** |     **300.01 ns** |     **3,517.9 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **128B**         |     **5,756.4 ns** |     **152.51 ns** |     **442.47 ns** |     **5,862.1 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 128B         |     7,509.6 ns |     149.58 ns |     409.48 ns |     7,560.8 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **137B**         |     **3,490.1 ns** |      **95.68 ns** |     **280.61 ns** |     **3,574.2 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **137B**         |     **5,933.8 ns** |     **129.50 ns** |     **367.36 ns** |     **5,970.3 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 137B         |     7,733.3 ns |     194.46 ns |     557.95 ns |     7,768.8 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **1KB**          |    **13,234.0 ns** |     **418.61 ns** |   **1,187.53 ns** |    **13,340.6 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **1KB**          |    **21,451.1 ns** |     **547.13 ns** |   **1,596.02 ns** |    **21,838.7 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 1KB          |    28,364.1 ns |     711.10 ns |   1,885.75 ns |    28,460.0 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **1025B**        |    **12,399.4 ns** |     **351.10 ns** |   **1,024.19 ns** |    **12,660.8 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **1025B**        |    **21,846.0 ns** |     **489.79 ns** |   **1,405.30 ns** |    **22,234.4 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 1025B        |    28,556.2 ns |     881.62 ns |   2,442.98 ns |    28,732.4 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **8KB**          |    **89,339.3 ns** |   **2,226.28 ns** |   **6,351.69 ns** |    **89,487.0 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **8KB**          |   **150,293.5 ns** |   **2,983.79 ns** |   **8,512.92 ns** |   **150,382.7 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 8KB          |   197,608.0 ns |   6,533.32 ns |  19,161.09 ns |   200,763.8 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **128KB**        | **1,389,885.9 ns** |  **37,648.06 ns** | **110,415.24 ns** | **1,418,786.3 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **128KB**        | **2,299,409.6 ns** |  **45,966.07 ns** | **107,444.23 ns** | **2,319,238.1 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 128KB        | 3,043,845.7 ns |  73,696.74 ns | 214,976.88 ns | 3,098,349.6 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 128B         |       354.0 ns |       8.90 ns |      25.95 ns |       357.0 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 128B         |       720.9 ns |      31.63 ns |      92.26 ns |       718.1 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 137B         |       350.5 ns |       8.97 ns |      25.74 ns |       352.4 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 137B         |       694.4 ns |      29.07 ns |      83.40 ns |       691.9 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 1KB          |     1,012.1 ns |      16.60 ns |      15.53 ns |     1,005.2 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 1KB          |     1,667.0 ns |      20.86 ns |      16.28 ns |     1,672.6 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 1025B        |       971.6 ns |       7.06 ns |       6.25 ns |       973.2 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 1025B        |     1,695.3 ns |      16.05 ns |      14.23 ns |     1,691.6 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 8KB          |     5,689.0 ns |      45.06 ns |      42.15 ns |     5,681.9 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 8KB          |    10,268.4 ns |      93.66 ns |      87.61 ns |    10,223.9 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 128KB        |    89,039.7 ns |     641.51 ns |     600.07 ns |    89,120.7 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 128KB        |   159,958.4 ns |     941.18 ns |     834.33 ns |   160,044.4 ns |     112 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 128B         |       229.0 ns |       1.77 ns |       1.66 ns |       228.5 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 128B         |       311.8 ns |       3.38 ns |       3.00 ns |       311.2 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 137B         |       486.7 ns |       3.67 ns |       3.43 ns |       486.1 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 137B         |       726.9 ns |       7.32 ns |       6.84 ns |       727.1 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 1KB          |     1,073.4 ns |      10.70 ns |      10.51 ns |     1,071.5 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 1KB          |     1,832.1 ns |      11.76 ns |      10.43 ns |     1,833.2 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 1025B        |     1,062.5 ns |       5.66 ns |       5.01 ns |     1,061.3 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 1025B        |     1,825.9 ns |      12.40 ns |      10.99 ns |     1,826.7 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 8KB          |     6,969.2 ns |      42.21 ns |      39.48 ns |     6,962.6 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 8KB          |    12,711.7 ns |     129.53 ns |     121.16 ns |    12,690.0 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 128KB        |   107,123.0 ns |     437.27 ns |     365.14 ns |   107,244.9 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 128KB        |   195,397.5 ns |   1,492.14 ns |   1,395.75 ns |   195,924.2 ns |     176 B |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **128B**         |     **1,441.2 ns** |       **8.56 ns** |       **8.01 ns** |     **1,439.4 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **128B**         |     **6,574.0 ns** |      **56.89 ns** |      **53.21 ns** |     **6,578.3 ns** |     **232 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **137B**         |     **1,420.5 ns** |       **5.50 ns** |       **5.14 ns** |     **1,421.9 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **137B**         |     **6,338.2 ns** |      **38.73 ns** |      **36.23 ns** |     **6,332.4 ns** |     **232 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **1KB**          |     **7,775.8 ns** |      **71.66 ns** |      **63.52 ns** |     **7,774.8 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **1KB**          |    **38,293.4 ns** |     **282.05 ns** |     **250.03 ns** |    **38,230.9 ns** |     **232 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **1025B**        |     **7,797.8 ns** |      **45.63 ns** |      **42.68 ns** |     **7,796.6 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **1025B**        |    **38,267.0 ns** |     **173.64 ns** |     **153.92 ns** |    **38,257.5 ns** |     **232 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **8KB**          |    **58,199.8 ns** |     **292.64 ns** |     **273.73 ns** |    **58,139.7 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **8KB**          |   **287,772.1 ns** |   **1,700.82 ns** |   **1,590.95 ns** |   **287,710.0 ns** |     **232 B** |
|                                                            |              |                |               |               |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **128KB**        | **1,161,012.3 ns** |  **23,163.35 ns** |  **48,350.53 ns** | **1,158,782.8 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **128KB**        | **5,919,605.1 ns** |  **42,327.61 ns** |  **37,522.32 ns** | **5,924,262.1 ns** |     **232 B** |
