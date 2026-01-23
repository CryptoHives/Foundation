```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                                 | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|------------------------------------------------------------ |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| **ComputeHash | BLAKE2b-512 | BouncyCastle**                    | **128B**         |       **129.8 ns** |      **0.84 ns** |      **0.66 ns** |       **129.7 ns** |     **176 B** |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 128B         |       143.0 ns |      1.60 ns |      1.25 ns |       143.4 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 128B         |       399.4 ns |      5.47 ns |      5.12 ns |       397.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 137B         |       208.8 ns |      1.82 ns |      1.52 ns |       208.5 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 137B         |       245.7 ns |      3.13 ns |      2.77 ns |       245.5 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 137B         |       756.1 ns |     12.73 ns |     11.90 ns |       752.5 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 1KB          |       748.7 ns |     11.44 ns |     10.70 ns |       743.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 1KB          |       884.4 ns |      9.77 ns |      8.16 ns |       885.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 1KB          |     2,883.1 ns |     50.11 ns |     46.88 ns |     2,869.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 1025B        |       831.5 ns |      2.05 ns |      1.60 ns |       832.0 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 1025B        |       994.7 ns |     16.43 ns |     12.83 ns |       997.4 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 1025B        |     3,256.7 ns |     45.14 ns |     42.22 ns |     3,233.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 8KB          |     5,678.5 ns |     99.54 ns |     93.11 ns |     5,640.3 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 8KB          |     7,061.2 ns |    112.62 ns |    105.34 ns |     7,019.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 8KB          |    22,659.8 ns |    113.55 ns |     88.65 ns |    22,642.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 128KB        |    89,713.4 ns |  1,563.85 ns |  1,462.83 ns |    88,811.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 128KB        |   112,106.5 ns |  1,569.63 ns |  1,391.44 ns |   111,725.5 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 128KB        |   365,298.7 ns |  6,923.73 ns |  6,476.46 ns |   362,880.5 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 128B         |       191.0 ns |      3.35 ns |      3.13 ns |       192.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3           | 128B         |       192.0 ns |      3.65 ns |      3.41 ns |       194.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 128B         |       192.7 ns |      3.80 ns |      3.73 ns |       191.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 128B         |       193.9 ns |      3.60 ns |      3.37 ns |       191.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 128B         |       628.2 ns |     10.71 ns |     10.02 ns |       623.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 137B         |       264.8 ns |      4.61 ns |      4.31 ns |       262.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 137B         |       268.7 ns |      2.45 ns |      1.91 ns |       268.0 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3           | 137B         |       271.0 ns |      0.81 ns |      0.63 ns |       270.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 137B         |       275.9 ns |      1.11 ns |      0.87 ns |       275.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 137B         |       917.4 ns |      9.18 ns |      8.59 ns |       915.0 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3           | 1KB          |     1,250.9 ns |      4.76 ns |      3.72 ns |     1,251.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 1KB          |     1,263.4 ns |     19.31 ns |     18.07 ns |     1,263.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 1KB          |     1,276.0 ns |     23.63 ns |     22.11 ns |     1,264.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 1KB          |     1,294.0 ns |     20.13 ns |     18.83 ns |     1,286.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 1KB          |     4,729.9 ns |     66.63 ns |     62.32 ns |     4,705.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 1025B        |     1,336.4 ns |     20.60 ns |     19.27 ns |     1,336.5 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 1025B        |     1,345.8 ns |     19.33 ns |     20.68 ns |     1,335.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3           | 1025B        |     1,362.5 ns |     20.17 ns |     18.87 ns |     1,355.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 1025B        |     1,383.1 ns |     24.49 ns |     22.91 ns |     1,371.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 1025B        |     4,985.1 ns |     26.84 ns |     22.41 ns |     4,981.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 8KB          |     9,737.6 ns |     80.08 ns |     66.87 ns |     9,718.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3           | 8KB          |     9,798.3 ns |     92.85 ns |     82.31 ns |     9,765.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 8KB          |     9,831.8 ns |    161.99 ns |    151.53 ns |     9,758.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 8KB          |    10,079.3 ns |    151.27 ns |    141.50 ns |    10,009.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 8KB          |    37,524.8 ns |    567.08 ns |    530.44 ns |    37,297.1 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 128KB        |   154,467.5 ns |    634.75 ns |    495.57 ns |   154,519.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 128KB        |   155,981.7 ns |  2,194.45 ns |  2,052.69 ns |   155,739.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3           | 128KB        |   157,848.8 ns |    576.07 ns |    449.76 ns |   157,643.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 128KB        |   160,583.0 ns |  2,259.97 ns |  2,113.98 ns |   159,999.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 128KB        |   601,744.0 ns |  9,105.98 ns |  8,517.74 ns |   599,858.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 128B         |       113.7 ns |      0.24 ns |      0.22 ns |       113.8 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 128B         |       384.0 ns |      1.16 ns |      1.03 ns |       384.0 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 128B         |       581.3 ns |      2.06 ns |      1.92 ns |       580.8 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 128B         |     1,261.2 ns |      4.71 ns |      3.93 ns |     1,261.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 137B         |       158.8 ns |      0.29 ns |      0.27 ns |       158.8 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 137B         |       449.1 ns |      0.80 ns |      0.67 ns |       449.1 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 137B         |       837.7 ns |      1.53 ns |      1.43 ns |       837.8 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 137B         |     1,885.5 ns |      4.70 ns |      4.39 ns |     1,885.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 1KB          |       763.5 ns |      2.21 ns |      2.07 ns |       763.9 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 1KB          |     1,299.3 ns |      2.23 ns |      1.98 ns |     1,299.3 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 1KB          |     4,233.0 ns |     11.39 ns |     10.65 ns |     4,236.2 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 1KB          |     9,500.7 ns |     27.33 ns |     22.83 ns |     9,496.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 1025B        |       867.0 ns |      1.45 ns |      1.36 ns |       867.2 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 1025B        |     1,447.8 ns |      3.74 ns |      3.49 ns |     1,446.8 ns |     224 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 1025B        |     4,843.8 ns |     14.82 ns |     13.87 ns |     4,844.0 ns |     224 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 1025B        |    10,714.4 ns |     15.57 ns |     13.80 ns |    10,714.2 ns |     168 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 8KB          |     1,207.5 ns |      4.49 ns |      4.20 ns |     1,207.7 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 8KB          |    10,376.9 ns |     23.90 ns |     21.18 ns |    10,374.5 ns |     896 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 8KB          |    35,408.0 ns |    134.50 ns |    119.23 ns |    35,399.4 ns |     896 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 8KB          |    78,657.2 ns |    159.24 ns |    141.16 ns |    78,687.1 ns |     504 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 128KB        |    14,337.6 ns |     32.06 ns |     26.77 ns |    14,329.4 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 128KB        |   169,523.9 ns |    347.35 ns |    324.91 ns |   169,580.5 ns |   14336 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 128KB        |   570,174.0 ns |  2,261.77 ns |  2,005.00 ns |   570,475.6 ns |   14336 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 128KB        | 1,263,588.0 ns |  2,723.69 ns |  2,414.48 ns | 1,263,448.5 ns |    7224 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 128B         |       278.3 ns |      1.00 ns |      0.94 ns |       278.6 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 128B         |       344.5 ns |      0.91 ns |      0.85 ns |       344.6 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 128B         |       353.9 ns |      1.54 ns |      1.44 ns |       353.8 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 128B         |       357.2 ns |      1.33 ns |      1.24 ns |       357.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 137B         |       270.3 ns |      1.18 ns |      1.10 ns |       270.5 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 137B         |       340.7 ns |      0.84 ns |      0.70 ns |       340.7 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 137B         |       351.7 ns |      0.62 ns |      0.55 ns |       351.7 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 137B         |       359.2 ns |      1.76 ns |      1.65 ns |       358.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 1KB          |     1,533.0 ns |      6.05 ns |      5.36 ns |     1,532.5 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 1KB          |     2,030.6 ns |      4.70 ns |      3.92 ns |     2,030.5 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 1KB          |     2,088.8 ns |      5.98 ns |      5.30 ns |     2,087.7 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 1KB          |     2,191.0 ns |      8.24 ns |      6.88 ns |     2,191.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 1025B        |     1,561.0 ns |     28.64 ns |     26.79 ns |     1,563.3 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 1025B        |     2,066.4 ns |     39.79 ns |     37.22 ns |     2,052.4 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 1025B        |     2,133.7 ns |     37.34 ns |     71.04 ns |     2,099.2 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 1025B        |     2,225.7 ns |     27.18 ns |     25.43 ns |     2,217.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 8KB          |    10,174.2 ns |    135.37 ns |    126.63 ns |    10,207.9 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 8KB          |    13,669.1 ns |    194.18 ns |    181.64 ns |    13,651.0 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 8KB          |    14,110.1 ns |    250.77 ns |    234.57 ns |    13,978.7 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 8KB          |    15,305.8 ns |    166.52 ns |    155.76 ns |    15,238.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 128KB        |   159,430.6 ns |  2,436.51 ns |  2,279.11 ns |   158,384.7 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 128KB        |   216,661.3 ns |  2,580.76 ns |  2,414.05 ns |   215,774.0 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 128KB        |   223,491.2 ns |  3,464.19 ns |  3,240.41 ns |   223,349.0 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 128KB        |   240,564.2 ns |  2,026.66 ns |  1,692.35 ns |   240,350.1 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 128B         |       282.7 ns |      3.22 ns |      3.01 ns |       281.1 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 128B         |       356.1 ns |      6.76 ns |      6.33 ns |       354.4 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 128B         |       363.5 ns |      4.69 ns |      4.39 ns |       363.2 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 128B         |       365.7 ns |      7.12 ns |      6.66 ns |       365.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 137B         |       536.3 ns |     10.71 ns |     10.02 ns |       532.8 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 137B         |       665.9 ns |      9.44 ns |      8.83 ns |       663.2 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 137B         |       676.2 ns |      7.47 ns |      6.62 ns |       674.4 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 137B         |       701.4 ns |     10.50 ns |      9.82 ns |       697.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 1KB          |     1,736.9 ns |     25.79 ns |     22.86 ns |     1,734.4 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 1KB          |     2,306.6 ns |     35.58 ns |     33.28 ns |     2,287.4 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 1KB          |     2,378.5 ns |     35.50 ns |     33.21 ns |     2,359.4 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 1KB          |     2,532.1 ns |     38.92 ns |     36.41 ns |     2,524.5 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 1025B        |     1,748.8 ns |     29.02 ns |     25.72 ns |     1,741.8 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 1025B        |     2,316.7 ns |     38.44 ns |     35.96 ns |     2,321.8 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 1025B        |     2,360.6 ns |      9.39 ns |      7.33 ns |     2,362.0 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 1025B        |     2,533.0 ns |     37.02 ns |     34.62 ns |     2,527.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 8KB          |    12,633.1 ns |    196.69 ns |    183.98 ns |    12,612.8 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 8KB          |    16,678.5 ns |    107.62 ns |     89.87 ns |    16,665.8 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 8KB          |    17,412.1 ns |    222.20 ns |    185.54 ns |    17,342.7 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 8KB          |    18,859.1 ns |    279.05 ns |    261.03 ns |    18,819.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 128KB        |   197,877.0 ns |  2,679.87 ns |  2,506.75 ns |   197,056.1 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 128KB        |   265,026.9 ns |  4,898.65 ns |  4,582.20 ns |   262,127.8 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 128KB        |   274,901.6 ns |  4,245.01 ns |  3,763.09 ns |   273,922.6 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 128KB        |   295,756.3 ns |  2,910.96 ns |  2,722.92 ns |   296,596.7 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 128B         |       242.5 ns |      4.54 ns |      4.25 ns |       241.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 128B         |       313.6 ns |      4.83 ns |      4.29 ns |       312.0 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 128B         |       324.3 ns |      3.73 ns |      3.30 ns |       323.3 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 128B         |       365.3 ns |      5.63 ns |      5.26 ns |       365.1 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 137B         |       496.5 ns |      5.87 ns |      5.20 ns |       496.2 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 137B         |       639.8 ns |     12.56 ns |     12.34 ns |       633.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 137B         |       656.0 ns |     11.37 ns |      9.49 ns |       652.0 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 137B         |       660.7 ns |      5.60 ns |      4.68 ns |       661.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 1KB          |     1,692.9 ns |     18.50 ns |     15.45 ns |     1,692.7 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 1KB          |     2,278.9 ns |     32.86 ns |     30.74 ns |     2,262.4 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 1KB          |     2,334.6 ns |     21.11 ns |     17.63 ns |     2,334.2 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 1KB          |     2,524.5 ns |     48.04 ns |     47.18 ns |     2,513.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 1025B        |     1,693.7 ns |     21.77 ns |     19.30 ns |     1,693.0 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 1025B        |     2,272.8 ns |     34.95 ns |     32.69 ns |     2,259.1 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 1025B        |     2,346.8 ns |     46.15 ns |     45.32 ns |     2,322.2 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 1025B        |     2,524.5 ns |     36.13 ns |     33.80 ns |     2,515.0 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 8KB          |    12,577.9 ns |    118.71 ns |    105.23 ns |    12,582.6 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 8KB          |    16,770.6 ns |    100.19 ns |     78.22 ns |    16,742.0 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 8KB          |    17,272.0 ns |     91.68 ns |     71.58 ns |    17,261.9 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 8KB          |    18,918.0 ns |    269.67 ns |    239.06 ns |    18,873.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 128KB        |   197,019.8 ns |  1,883.79 ns |  1,573.05 ns |   197,237.7 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 128KB        |   263,929.7 ns |  2,202.71 ns |  1,839.36 ns |   263,239.1 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 128KB        |   273,988.2 ns |  4,479.71 ns |  4,190.33 ns |   271,546.5 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 128KB        |   296,100.6 ns |  4,832.01 ns |  4,519.86 ns |   296,635.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **128B**         |       **746.9 ns** |     **13.70 ns** |     **12.81 ns** |       **746.4 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **128B**         |     **1,077.8 ns** |     **15.89 ns** |     **14.08 ns** |     **1,078.8 ns** |     **296 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 128B         |     2,075.8 ns |     38.66 ns |     36.16 ns |     2,066.1 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **137B**         |       **757.9 ns** |     **14.89 ns** |     **17.73 ns** |       **765.1 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **137B**         |     **1,080.5 ns** |     **14.35 ns** |     **12.72 ns** |     **1,078.7 ns** |     **312 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 137B         |     2,097.7 ns |     21.80 ns |     20.40 ns |     2,106.1 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **1KB**          |     **2,039.6 ns** |     **34.80 ns** |     **32.55 ns** |     **2,027.4 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **1KB**          |     **2,632.9 ns** |     **39.39 ns** |     **34.92 ns** |     **2,620.2 ns** |    **1192 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 1KB          |     3,907.8 ns |     54.39 ns |     50.88 ns |     3,907.2 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **1025B**        |     **2,021.0 ns** |     **40.45 ns** |     **39.73 ns** |     **1,999.7 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **1025B**        |     **2,564.5 ns** |     **26.68 ns** |     **22.28 ns** |     **2,559.0 ns** |    **1200 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 1025B        |     3,867.0 ns |     39.72 ns |     35.21 ns |     3,871.9 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **8KB**          |    **10,590.2 ns** |    **111.52 ns** |    **104.31 ns** |    **10,591.6 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **8KB**          |    **13,105.2 ns** |    **146.48 ns** |    **137.02 ns** |    **13,097.0 ns** |    **8360 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 8KB          |    16,956.0 ns |    279.62 ns |    261.55 ns |    16,855.2 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **128KB**        |   **161,226.0 ns** |  **1,946.09 ns** |  **1,820.37 ns** |   **161,517.3 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **128KB**        |   **227,518.2 ns** |  **3,795.47 ns** |  **3,550.29 ns** |   **225,814.3 ns** |  **131263 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 128KB        |   245,225.5 ns |  4,688.65 ns |  4,385.77 ns |   243,581.8 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **128B**         |       **754.2 ns** |      **9.95 ns** |      **9.31 ns** |       **752.7 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **128B**         |     **1,080.7 ns** |     **10.54 ns** |      **8.80 ns** |     **1,081.6 ns** |     **360 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 128B         |     2,043.8 ns |     29.07 ns |     27.20 ns |     2,038.8 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **137B**         |     **1,006.3 ns** |     **16.39 ns** |     **15.33 ns** |     **1,003.3 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **137B**         |     **1,330.4 ns** |     **12.64 ns** |     **11.82 ns** |     **1,327.3 ns** |     **376 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 137B         |     2,333.4 ns |     31.09 ns |     29.08 ns |     2,324.1 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **1KB**          |     **2,186.6 ns** |     **28.84 ns** |     **26.98 ns** |     **2,180.6 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **1KB**          |     **2,812.7 ns** |     **33.97 ns** |     **31.77 ns** |     **2,805.3 ns** |    **1256 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 1KB          |     4,160.4 ns |     26.19 ns |     20.45 ns |     4,159.2 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **1025B**        |     **2,215.1 ns** |     **37.10 ns** |     **34.70 ns** |     **2,200.3 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **1025B**        |     **2,827.0 ns** |     **54.60 ns** |     **51.07 ns** |     **2,816.0 ns** |    **1264 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 1025B        |     4,190.1 ns |     67.95 ns |     63.56 ns |     4,196.4 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **8KB**          |    **13,105.6 ns** |    **203.41 ns** |    **190.27 ns** |    **13,079.5 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **8KB**          |    **15,963.2 ns** |    **261.50 ns** |    **244.60 ns** |    **15,902.6 ns** |    **8424 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 8KB          |    20,434.7 ns |    215.68 ns |    180.10 ns |    20,452.5 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **128KB**        |   **196,003.9 ns** |  **1,268.94 ns** |  **1,059.62 ns** |   **195,953.9 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **128KB**        |   **268,936.5 ns** |  **3,215.97 ns** |  **3,008.22 ns** |   **269,161.9 ns** |  **131327 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 128KB        |   298,589.8 ns |  4,200.14 ns |  3,928.82 ns |   297,729.6 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 128B         |       232.1 ns |      2.08 ns |      1.74 ns |       231.8 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 128B         |       257.2 ns |      4.03 ns |      3.77 ns |       256.1 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 128B         |       268.0 ns |      2.94 ns |      2.45 ns |       268.0 ns |     584 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 137B         |       231.3 ns |      2.83 ns |      2.65 ns |       230.3 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 137B         |       250.4 ns |      1.54 ns |      1.44 ns |       250.6 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 137B         |       259.2 ns |      4.03 ns |      3.57 ns |       257.3 ns |     584 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 1KB          |       941.0 ns |      3.56 ns |      3.33 ns |       941.3 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 1KB          |     1,182.8 ns |      7.24 ns |      6.04 ns |     1,180.8 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 1KB          |     1,218.6 ns |      3.60 ns |      3.37 ns |     1,219.2 ns |     584 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 1025B        |       939.5 ns |      4.36 ns |      4.08 ns |       937.8 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 1025B        |     1,176.9 ns |      3.65 ns |      3.24 ns |     1,177.0 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 1025B        |     1,217.9 ns |      3.27 ns |      3.06 ns |     1,217.3 ns |     584 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 8KB          |     6,146.7 ns |     30.94 ns |     28.94 ns |     6,150.8 ns |    1056 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 8KB          |     7,912.9 ns |     27.88 ns |     26.08 ns |     7,901.3 ns |    1056 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 8KB          |     8,304.4 ns |     14.03 ns |     10.95 ns |     8,303.2 ns |    1056 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 128KB        |    91,837.3 ns |    406.71 ns |    339.62 ns |    91,891.4 ns |    8136 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 128KB        |   118,307.1 ns |    183.61 ns |    171.75 ns |   118,289.1 ns |    8136 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 128KB        |   124,284.4 ns |    320.89 ns |    284.46 ns |   124,213.0 ns |    8136 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 128B         |       228.6 ns |      0.93 ns |      0.87 ns |       228.3 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 128B         |       252.2 ns |      1.25 ns |      1.17 ns |       251.8 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 128B         |       259.8 ns |      1.38 ns |      1.29 ns |       259.7 ns |     616 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 137B         |       399.8 ns |      2.25 ns |      2.10 ns |       399.3 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 137B         |       444.2 ns |      1.41 ns |      1.25 ns |       444.6 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 137B         |       449.9 ns |      1.67 ns |      1.56 ns |       449.5 ns |     616 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 1KB          |     1,031.7 ns |      3.68 ns |      3.07 ns |     1,032.2 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 1KB          |     1,312.9 ns |      2.50 ns |      2.34 ns |     1,312.5 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 1KB          |     1,353.6 ns |      4.93 ns |      4.12 ns |     1,352.8 ns |     616 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 1025B        |     1,035.9 ns |      3.79 ns |      3.54 ns |     1,035.7 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 1025B        |     1,306.9 ns |      3.38 ns |      3.00 ns |     1,306.5 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 1025B        |     1,350.9 ns |      0.89 ns |      0.74 ns |     1,351.1 ns |     616 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 8KB          |     7,277.2 ns |     27.69 ns |     25.91 ns |     7,278.8 ns |    1056 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 8KB          |     9,344.8 ns |     31.51 ns |     27.93 ns |     9,347.2 ns |    1056 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 8KB          |     9,827.9 ns |     26.47 ns |     24.76 ns |     9,822.9 ns |    1056 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 128KB        |   112,867.6 ns |    440.49 ns |    412.04 ns |   112,932.7 ns |    7656 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 128KB        |   145,197.4 ns |    372.72 ns |    348.64 ns |   145,170.9 ns |    7656 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 128KB        |   152,666.5 ns |    329.67 ns |    308.37 ns |   152,699.3 ns |    7656 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 128B         |       292.7 ns |      1.22 ns |      1.14 ns |       292.3 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **128B**         |       **352.2 ns** |      **2.19 ns** |      **1.83 ns** |       **352.3 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **128B**         |       **392.8 ns** |      **0.92 ns** |      **0.77 ns** |       **392.7 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 137B         |       293.0 ns |      0.90 ns |      0.84 ns |       293.0 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **137B**         |       **353.8 ns** |      **1.04 ns** |      **0.81 ns** |       **354.0 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **137B**         |       **391.9 ns** |      **0.65 ns** |      **0.57 ns** |       **391.9 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 1KB          |     1,394.5 ns |      2.88 ns |      2.69 ns |     1,393.7 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **1KB**          |     **1,830.1 ns** |     **11.81 ns** |     **11.05 ns** |     **1,828.9 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **1KB**          |     **2,035.7 ns** |      **4.66 ns** |      **4.36 ns** |     **2,035.8 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 1025B        |     1,406.7 ns |      1.96 ns |      1.83 ns |     1,406.8 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **1025B**        |     **1,829.5 ns** |      **6.69 ns** |      **6.25 ns** |     **1,828.7 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **1025B**        |     **2,033.4 ns** |      **5.64 ns** |      **5.28 ns** |     **2,034.0 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 8KB          |    10,194.3 ns |     10.14 ns |      9.49 ns |    10,193.2 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **8KB**          |    **13,634.8 ns** |     **79.64 ns** |     **74.49 ns** |    **13,632.5 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **8KB**          |    **15,026.2 ns** |     **21.03 ns** |     **18.64 ns** |    **15,022.1 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 128KB        |   160,958.4 ns |    262.68 ns |    245.71 ns |   161,029.9 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **128KB**        |   **215,475.6 ns** |    **820.96 ns** |    **727.76 ns** |   **215,319.7 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **128KB**        |   **238,854.9 ns** |    **413.57 ns** |    **386.86 ns** |   **238,833.5 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | RIPEMD-160 | BouncyCastle                     | 128B         |       670.1 ns |      2.43 ns |      2.15 ns |       670.1 ns |      96 B |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **128B**         |       **990.5 ns** |     **13.25 ns** |     **11.06 ns** |       **988.1 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **137B**         |       **671.9 ns** |      **2.59 ns** |      **2.42 ns** |       **671.7 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **137B**         |       **983.8 ns** |      **6.66 ns** |      **5.20 ns** |       **982.6 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **1KB**          |     **3,609.2 ns** |      **7.73 ns** |      **7.23 ns** |     **3,612.0 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **1KB**          |     **5,403.4 ns** |     **68.57 ns** |     **86.72 ns** |     **5,377.2 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **1025B**        |     **3,610.0 ns** |      **6.04 ns** |      **5.35 ns** |     **3,609.3 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **1025B**        |     **5,442.5 ns** |     **90.08 ns** |    **152.97 ns** |     **5,380.5 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **8KB**          |    **26,628.0 ns** |     **46.78 ns** |     **43.76 ns** |    **26,626.6 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **8KB**          |    **41,478.7 ns** |    **548.56 ns** |    **428.28 ns** |    **41,395.3 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **128KB**        |   **425,823.0 ns** |    **897.96 ns** |    **796.02 ns** |   **425,605.1 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **128KB**        |   **690,437.5 ns** | **17,098.40 ns** | **49,332.79 ns** |   **662,428.9 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **128B**         |       **256.8 ns** |      **1.52 ns** |      **1.35 ns** |       **256.5 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 128B         |       460.6 ns |      1.38 ns |      1.22 ns |       460.3 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **128B**         |       **486.7 ns** |      **3.44 ns** |      **3.22 ns** |       **486.6 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **137B**         |       **257.2 ns** |      **1.19 ns** |      **1.12 ns** |       **257.5 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 137B         |       463.9 ns |      1.85 ns |      1.73 ns |       463.6 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **137B**         |       **482.1 ns** |      **1.46 ns** |      **1.30 ns** |       **482.0 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **1KB**          |     **1,125.4 ns** |      **3.60 ns** |      **3.19 ns** |     **1,125.1 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 1KB          |     2,441.8 ns |     11.32 ns |     10.59 ns |     2,438.9 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **1KB**          |     **2,491.9 ns** |     **10.58 ns** |      **9.38 ns** |     **2,490.1 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **1025B**        |     **1,129.0 ns** |      **4.19 ns** |      **3.71 ns** |     **1,129.1 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 1025B        |     2,438.5 ns |      9.53 ns |      8.44 ns |     2,438.9 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **1025B**        |     **2,487.7 ns** |     **14.57 ns** |     **13.63 ns** |     **2,482.2 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **8KB**          |     **8,090.4 ns** |     **29.36 ns** |     **26.02 ns** |     **8,080.9 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 8KB          |    18,159.3 ns |     91.20 ns |     80.85 ns |    18,148.9 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **8KB**          |    **18,383.7 ns** |     **40.91 ns** |     **36.27 ns** |    **18,373.1 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **128KB**        |   **127,593.6 ns** |    **618.46 ns** |    **578.51 ns** |   **127,657.8 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 128KB        |   288,020.7 ns |  1,449.32 ns |  1,284.79 ns |   287,678.0 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **128KB**        |   **291,772.7 ns** |  **1,123.88 ns** |    **996.29 ns** |   **291,998.4 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **128B**         |       **581.4 ns** |      **2.45 ns** |      **2.29 ns** |       **581.1 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **128B**         |       **588.9 ns** |      **2.49 ns** |      **2.08 ns** |       **589.1 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **137B**         |       **581.8 ns** |      **2.11 ns** |      **1.87 ns** |       **581.9 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **137B**         |       **609.1 ns** |      **2.66 ns** |      **2.35 ns** |       **608.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **1KB**          |     **3,101.3 ns** |     **13.22 ns** |     **12.37 ns** |     **3,100.4 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **1KB**          |     **3,197.6 ns** |     **18.24 ns** |     **17.06 ns** |     **3,195.8 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **1025B**        |     **3,098.7 ns** |     **13.06 ns** |     **10.90 ns** |     **3,098.1 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **1025B**        |     **3,193.9 ns** |     **14.91 ns** |     **13.94 ns** |     **3,191.3 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **8KB**          |    **23,187.7 ns** |     **89.58 ns** |     **83.79 ns** |    **23,202.4 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **8KB**          |    **23,788.3 ns** |    **109.38 ns** |     **96.96 ns** |    **23,786.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **128KB**        |   **366,428.3 ns** |  **1,156.89 ns** |  **1,082.15 ns** |   **366,291.6 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **128KB**        |   **376,348.8 ns** |  **1,843.94 ns** |  **1,634.61 ns** |   **376,008.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **128B**         |       **129.3 ns** |      **0.52 ns** |      **0.49 ns** |       **129.1 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 128B         |       577.3 ns |      1.93 ns |      1.61 ns |       577.7 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **128B**         |       **611.1 ns** |      **1.54 ns** |      **1.36 ns** |       **611.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **137B**         |       **133.2 ns** |      **0.67 ns** |      **0.59 ns** |       **133.2 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 137B         |       572.8 ns |      2.23 ns |      1.97 ns |       573.2 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **137B**         |       **605.1 ns** |      **3.02 ns** |      **2.67 ns** |       **604.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **1KB**          |       **491.3 ns** |      **2.48 ns** |      **2.20 ns** |       **491.3 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 1KB          |     3,057.3 ns |     10.72 ns |      9.50 ns |     3,056.9 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **1KB**          |     **3,173.8 ns** |     **16.13 ns** |     **15.08 ns** |     **3,171.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **1025B**        |       **490.1 ns** |      **1.18 ns** |      **1.05 ns** |       **489.7 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 1025B        |     3,057.3 ns |     13.02 ns |     12.18 ns |     3,056.2 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **1025B**        |     **3,176.2 ns** |     **14.04 ns** |     **13.13 ns** |     **3,171.2 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **8KB**          |     **3,306.5 ns** |      **5.98 ns** |      **5.30 ns** |     **3,306.5 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 8KB          |    22,925.2 ns |     91.26 ns |     85.36 ns |    22,922.0 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **8KB**          |    **23,648.8 ns** |    **113.49 ns** |    **100.60 ns** |    **23,655.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **128KB**        |    **51,571.6 ns** |     **71.10 ns** |     **59.38 ns** |    **51,587.2 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 128KB        |   365,993.7 ns |  2,441.72 ns |  2,164.52 ns |   365,339.4 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **128KB**        |   **374,080.7 ns** |  **1,673.92 ns** |  **1,565.79 ns** |   **373,470.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **128B**         |       **380.7 ns** |      **1.86 ns** |      **1.65 ns** |       **380.6 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 128B         |       508.2 ns |      2.86 ns |      2.53 ns |       507.2 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **128B**         |       **541.0 ns** |      **2.38 ns** |      **1.98 ns** |       **540.7 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **137B**         |       **375.2 ns** |      **1.28 ns** |      **1.14 ns** |       **374.9 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 137B         |       523.3 ns |      3.60 ns |      3.37 ns |       522.7 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **137B**         |       **537.5 ns** |      **3.63 ns** |      **3.40 ns** |       **537.3 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **1KB**          |     **1,424.4 ns** |      **7.66 ns** |      **7.17 ns** |     **1,425.1 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 1KB          |     2,165.0 ns |     42.84 ns |     75.04 ns |     2,124.6 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **1KB**          |     **2,231.5 ns** |     **44.40 ns** |     **90.69 ns** |     **2,218.7 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **1025B**        |     **1,425.3 ns** |      **6.48 ns** |      **5.75 ns** |     **1,425.9 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 1025B        |     2,121.1 ns |     15.88 ns |     14.85 ns |     2,121.0 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **1025B**        |     **2,137.6 ns** |     **11.48 ns** |     **10.18 ns** |     **2,137.7 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **8KB**          |     **9,768.7 ns** |     **63.72 ns** |     **56.48 ns** |     **9,749.9 ns** |     **144 B** |
| **ComputeHash | SHA-384 | CryptoHives**                         | **8KB**          |    **14,857.4 ns** |     **85.39 ns** |     **75.70 ns** |    **14,848.5 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                        | **8KB**          |    **14,901.4 ns** |     **53.66 ns** |     **47.57 ns** |    **14,903.2 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-384 | OS Native                           | 128KB        |   152,497.3 ns |    641.16 ns |    599.74 ns |   152,398.9 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **128KB**        |   **232,655.7 ns** |    **881.56 ns** |    **824.61 ns** |   **232,625.6 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                        | **128KB**        |   **234,655.2 ns** |    **727.89 ns** |    **645.26 ns** |   **234,553.0 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-512 | OS Native                           | 128B         |       377.2 ns |      1.07 ns |      0.95 ns |       377.3 ns |     176 B |
| ComputeHash | SHA-512 | BouncyCastle                        | 128B         |       504.3 ns |      3.00 ns |      2.66 ns |       503.6 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **128B**         |       **565.4 ns** |      **1.92 ns** |      **1.60 ns** |       **565.4 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **137B**         |       **374.5 ns** |      **2.34 ns** |      **2.19 ns** |       **373.8 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 137B         |       506.6 ns |      1.76 ns |      1.56 ns |       506.2 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **137B**         |       **562.5 ns** |      **4.95 ns** |      **4.39 ns** |       **563.2 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **1KB**          |     **1,417.6 ns** |      **4.58 ns** |      **4.06 ns** |     **1,418.3 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 1KB          |     2,119.3 ns |     10.85 ns |     10.15 ns |     2,118.2 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **1KB**          |     **2,243.5 ns** |      **9.10 ns** |      **8.07 ns** |     **2,247.2 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **1025B**        |     **1,425.2 ns** |      **5.21 ns** |      **4.87 ns** |     **1,424.0 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 1025B        |     2,113.2 ns |      7.78 ns |      6.90 ns |     2,113.4 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **1025B**        |     **2,241.4 ns** |     **10.87 ns** |      **9.63 ns** |     **2,243.3 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **8KB**          |     **9,724.3 ns** |     **31.07 ns** |     **27.54 ns** |     **9,721.6 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 8KB          |    14,892.2 ns |     50.39 ns |     47.13 ns |    14,888.4 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **8KB**          |    **15,629.8 ns** |     **77.98 ns** |     **72.95 ns** |    **15,636.1 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **128KB**        |   **152,742.9 ns** |    **840.65 ns** |    **786.35 ns** |   **152,476.4 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 128KB        |   234,036.9 ns |    744.29 ns |    696.21 ns |   233,885.5 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **128KB**        |   **244,464.7 ns** |  **1,467.67 ns** |  **1,372.86 ns** |   **244,523.6 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **128B**         |       **515.8 ns** |      **1.11 ns** |      **0.93 ns** |       **515.7 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **128B**         |       **538.8 ns** |      **4.21 ns** |      **3.94 ns** |       **538.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **137B**         |       **521.2 ns** |      **1.00 ns** |      **0.83 ns** |       **521.2 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **137B**         |       **535.2 ns** |      **2.21 ns** |      **1.84 ns** |       **534.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **1KB**          |     **2,121.1 ns** |     **10.27 ns** |      **9.61 ns** |     **2,119.1 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **1KB**          |     **2,132.4 ns** |     **12.58 ns** |     **11.77 ns** |     **2,129.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **1025B**        |     **2,123.9 ns** |      **7.95 ns** |      **6.63 ns** |     **2,123.8 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **1025B**        |     **2,129.7 ns** |     **10.61 ns** |      **9.92 ns** |     **2,127.7 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-512/224 | CryptoHives                     | 8KB          |    14,820.9 ns |     38.50 ns |     34.13 ns |    14,808.8 ns |     112 B |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **8KB**          |    **14,938.5 ns** |     **82.14 ns** |     **76.84 ns** |    **14,922.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **128KB**        |   **233,173.7 ns** |  **1,297.82 ns** |  **1,213.99 ns** |   **233,104.4 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **128KB**        |   **234,381.1 ns** |    **937.91 ns** |    **877.32 ns** |   **234,174.1 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-512/256 | BouncyCastle                    | 128B         |       519.3 ns |      2.74 ns |      2.43 ns |       520.1 ns |     112 B |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **128B**         |       **537.4 ns** |      **2.11 ns** |      **1.87 ns** |       **537.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **137B**         |       **524.5 ns** |      **1.93 ns** |      **1.51 ns** |       **524.6 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **137B**         |       **537.5 ns** |      **2.21 ns** |      **1.84 ns** |       **537.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **1KB**          |     **2,125.5 ns** |     **14.59 ns** |     **12.93 ns** |     **2,123.2 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **1KB**          |     **2,141.6 ns** |     **11.68 ns** |     **10.93 ns** |     **2,142.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **1025B**        |     **2,125.5 ns** |      **8.40 ns** |      **7.45 ns** |     **2,126.1 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **1025B**        |     **2,132.9 ns** |     **13.19 ns** |     **12.34 ns** |     **2,128.4 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-512/256 | CryptoHives                     | 8KB          |    14,858.2 ns |     71.04 ns |     66.45 ns |    14,831.0 ns |     112 B |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **8KB**          |    **14,911.0 ns** |     **64.83 ns** |     **60.64 ns** |    **14,908.2 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **128KB**        |   **232,270.4 ns** |    **921.17 ns** |    **861.67 ns** |   **232,354.2 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **128KB**        |   **233,897.3 ns** |    **634.11 ns** |    **593.14 ns** |   **233,984.4 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 128B         |       242.2 ns |      1.25 ns |      1.17 ns |       242.0 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 128B         |       312.3 ns |      0.91 ns |      0.85 ns |       312.4 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 128B         |       324.1 ns |      0.75 ns |      0.70 ns |       324.0 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 128B         |       361.1 ns |      1.34 ns |      1.19 ns |       361.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 137B         |       239.3 ns |      2.13 ns |      1.99 ns |       238.6 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 137B         |       308.9 ns |      0.77 ns |      0.68 ns |       308.7 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 137B         |       320.7 ns |      1.05 ns |      0.93 ns |       320.5 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 137B         |       359.5 ns |      1.15 ns |      1.02 ns |       359.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 1KB          |     1,703.1 ns |      8.94 ns |      8.37 ns |     1,702.5 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 1KB          |     2,256.6 ns |      9.07 ns |      8.48 ns |     2,255.7 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 1KB          |     2,328.0 ns |      8.69 ns |      8.13 ns |     2,330.0 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 1KB          |     2,493.6 ns |      6.17 ns |      5.47 ns |     2,493.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 1025B        |     1,704.2 ns |      5.52 ns |      5.17 ns |     1,702.6 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 1025B        |     2,259.7 ns |      7.76 ns |      7.26 ns |     2,260.7 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 1025B        |     2,327.6 ns |     12.31 ns |     10.91 ns |     2,327.4 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 1025B        |     2,478.9 ns |      7.33 ns |      6.49 ns |     2,481.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 8KB          |    11,566.4 ns |     45.86 ns |     40.65 ns |    11,557.0 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 8KB          |    15,551.2 ns |     68.80 ns |     64.35 ns |    15,554.8 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 8KB          |    16,006.6 ns |     67.13 ns |     62.79 ns |    16,007.0 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 8KB          |    17,388.9 ns |     63.00 ns |     58.93 ns |    17,385.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 128KB        |   183,778.9 ns |    871.71 ns |    815.40 ns |   183,721.4 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 128KB        |   246,043.5 ns |    785.96 ns |    735.19 ns |   245,961.9 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 128KB        |   255,244.6 ns |    751.98 ns |    703.41 ns |   255,138.5 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 128KB        |   279,412.3 ns |  1,853.49 ns |  1,733.75 ns |   278,381.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 128B         |       239.0 ns |      1.16 ns |      1.09 ns |       238.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 128B         |       299.1 ns |      4.00 ns |      3.34 ns |       297.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 128B         |       309.8 ns |      0.63 ns |      0.59 ns |       309.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 128B         |       321.0 ns |      0.65 ns |      0.58 ns |       321.1 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 128B         |       359.1 ns |      1.85 ns |      1.73 ns |       359.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 137B         |       485.8 ns |      2.84 ns |      2.51 ns |       484.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 137B         |       534.4 ns |      6.26 ns |      5.55 ns |       532.2 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 137B         |       627.6 ns |      1.21 ns |      1.07 ns |       628.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 137B         |       647.9 ns |      1.60 ns |      1.50 ns |       647.8 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 137B         |       653.7 ns |      2.32 ns |      2.17 ns |       653.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 1KB          |     1,671.3 ns |      4.09 ns |      3.62 ns |     1,672.2 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 1KB          |     1,950.2 ns |     11.83 ns |     11.07 ns |     1,951.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 1KB          |     2,243.4 ns |      6.15 ns |      5.13 ns |     2,241.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 1KB          |     2,339.7 ns |      8.10 ns |      7.58 ns |     2,341.0 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 1KB          |     2,485.0 ns |     11.48 ns |     10.74 ns |     2,481.7 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 1025B        |     1,670.8 ns |      9.03 ns |      8.00 ns |     1,667.1 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 1025B        |     1,949.7 ns |      8.58 ns |      7.16 ns |     1,949.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 1025B        |     2,231.4 ns |      4.60 ns |      4.30 ns |     2,230.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 1025B        |     2,316.0 ns |      6.53 ns |      6.11 ns |     2,316.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 1025B        |     2,491.6 ns |     11.90 ns |     11.13 ns |     2,488.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 8KB          |    12,382.3 ns |     64.77 ns |     60.59 ns |    12,384.7 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 8KB          |    14,409.4 ns |     85.68 ns |     80.14 ns |    14,403.3 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 8KB          |    16,702.2 ns |     46.86 ns |     43.84 ns |    16,692.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 8KB          |    17,186.9 ns |     56.44 ns |     52.80 ns |    17,172.8 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 8KB          |    18,595.6 ns |     67.87 ns |     63.48 ns |    18,608.0 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 128KB        |   194,883.1 ns |    996.95 ns |    932.55 ns |   194,625.4 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 128KB        |   227,116.0 ns |  1,048.82 ns |    981.06 ns |   226,953.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 128KB        |   262,856.6 ns |    722.79 ns |    676.10 ns |   262,870.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 128KB        |   271,271.3 ns |  1,013.56 ns |    898.49 ns |   270,985.5 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 128KB        |   292,540.1 ns |    728.41 ns |    608.26 ns |   292,475.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 128B         |       463.7 ns |      2.41 ns |      2.14 ns |       463.4 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 128B         |       529.5 ns |      4.30 ns |      3.81 ns |       529.0 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 128B         |       604.9 ns |      1.61 ns |      1.43 ns |       605.2 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 128B         |       628.4 ns |      2.22 ns |      2.07 ns |       627.6 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 128B         |       651.8 ns |      2.31 ns |      2.16 ns |       651.3 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 137B         |       459.3 ns |      1.55 ns |      1.45 ns |       458.9 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 137B         |       528.4 ns |      1.82 ns |      1.52 ns |       528.2 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 137B         |       601.7 ns |      1.35 ns |      1.26 ns |       601.2 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 137B         |       624.9 ns |      1.80 ns |      1.68 ns |       624.7 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 137B         |       650.4 ns |      1.47 ns |      1.22 ns |       650.3 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 1KB          |     2,028.1 ns |      7.14 ns |      5.97 ns |     2,028.0 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 1KB          |     2,401.1 ns |     14.28 ns |     12.66 ns |     2,394.3 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 1KB          |     2,817.0 ns |      6.67 ns |      5.91 ns |     2,815.8 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 1KB          |     2,942.4 ns |      8.01 ns |      7.49 ns |     2,945.1 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 1KB          |     3,072.7 ns |     13.98 ns |     12.39 ns |     3,074.4 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 1025B        |     2,033.2 ns |      8.66 ns |      8.10 ns |     2,033.6 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 1025B        |     2,410.0 ns |     17.58 ns |     16.45 ns |     2,407.2 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 1025B        |     2,792.6 ns |     24.19 ns |     21.44 ns |     2,782.5 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 1025B        |     2,810.6 ns |      5.33 ns |      4.45 ns |     2,811.9 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 1025B        |     3,070.2 ns |      9.10 ns |      8.07 ns |     3,070.3 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 8KB          |    15,774.6 ns |     63.91 ns |     53.37 ns |    15,771.9 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 8KB          |    18,538.7 ns |    159.70 ns |    149.38 ns |    18,491.9 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 8KB          |    21,435.8 ns |     48.52 ns |     45.39 ns |    21,431.7 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 8KB          |    21,861.1 ns |     56.39 ns |     49.99 ns |    21,858.7 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 8KB          |    23,770.2 ns |    110.87 ns |     98.28 ns |    23,775.3 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 128KB        |   251,248.3 ns |  1,126.86 ns |    998.93 ns |   250,796.9 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 128KB        |   295,928.6 ns |  2,632.74 ns |  2,333.85 ns |   295,390.5 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 128KB        |   342,742.6 ns |    849.59 ns |    794.71 ns |   342,780.9 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 128KB        |   347,883.5 ns |  1,073.61 ns |    951.73 ns |   348,128.2 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 128KB        |   379,751.2 ns |  1,028.79 ns |    962.33 ns |   379,688.8 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 128B         |       435.9 ns |      2.44 ns |      2.28 ns |       436.0 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 128B         |       528.7 ns |      3.15 ns |      2.80 ns |       528.6 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 128B         |       578.7 ns |      1.76 ns |      1.47 ns |       578.6 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 128B         |       602.1 ns |      1.40 ns |      1.31 ns |       602.1 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 128B         |       650.7 ns |      2.87 ns |      2.68 ns |       650.8 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 137B         |       433.9 ns |      1.43 ns |      1.20 ns |       434.2 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 137B         |       532.4 ns |      3.21 ns |      3.00 ns |       531.5 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 137B         |       577.1 ns |      5.02 ns |      4.19 ns |       575.3 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 137B         |       596.9 ns |      2.29 ns |      2.03 ns |       597.0 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 137B         |       650.7 ns |      2.63 ns |      2.46 ns |       650.1 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 1KB          |     3,013.6 ns |      8.25 ns |      6.44 ns |     3,014.1 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 1KB          |     3,546.4 ns |      9.70 ns |      8.60 ns |     3,547.6 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 1KB          |     4,105.2 ns |      7.97 ns |      7.07 ns |     4,107.7 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 1KB          |     4,191.6 ns |      9.24 ns |      8.65 ns |     4,187.9 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 1KB          |     4,547.8 ns |     19.46 ns |     17.25 ns |     4,547.5 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 1025B        |     3,016.9 ns |     15.32 ns |     14.33 ns |     3,017.4 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 1025B        |     3,549.5 ns |     12.12 ns |     10.75 ns |     3,546.9 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 1025B        |     4,098.0 ns |     17.28 ns |     15.32 ns |     4,099.8 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 1025B        |     4,188.1 ns |      5.43 ns |      4.24 ns |     4,188.3 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 1025B        |     4,537.6 ns |     21.40 ns |     20.01 ns |     4,532.1 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 8KB          |    22,467.4 ns |    110.03 ns |    102.92 ns |    22,461.2 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 8KB          |    26,523.7 ns |    124.06 ns |    109.97 ns |    26,534.6 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 8KB          |    30,917.4 ns |    119.35 ns |    111.64 ns |    30,898.5 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 8KB          |    31,421.1 ns |     74.00 ns |     69.22 ns |    31,416.7 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 8KB          |    34,265.1 ns |    221.56 ns |    207.25 ns |    34,214.3 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 128KB        |   358,973.2 ns |  1,700.88 ns |  1,507.78 ns |   358,533.0 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 128KB        |   420,404.7 ns |    589.62 ns |    460.34 ns |   420,418.8 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 128KB        |   494,876.4 ns |  1,899.49 ns |  1,776.79 ns |   495,119.1 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 128KB        |   502,218.9 ns |  1,511.69 ns |  1,414.04 ns |   502,094.8 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 128KB        |   548,817.5 ns |  1,670.49 ns |  1,480.85 ns |   548,983.3 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 128B         |       275.3 ns |      2.05 ns |      1.91 ns |       274.5 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 128B         |       342.8 ns |      0.80 ns |      0.71 ns |       342.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 128B         |       352.7 ns |      1.18 ns |      1.05 ns |       352.6 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 128B         |       363.3 ns |      1.92 ns |      1.80 ns |       363.2 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 128B         |       376.2 ns |      1.27 ns |      1.19 ns |       376.1 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 137B         |       271.6 ns |      1.33 ns |      1.18 ns |       271.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 137B         |       341.2 ns |      0.85 ns |      0.71 ns |       341.1 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 137B         |       351.0 ns |      0.77 ns |      0.72 ns |       350.8 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 137B         |       358.3 ns |      1.23 ns |      1.03 ns |       358.5 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 137B         |       383.6 ns |      1.13 ns |      1.00 ns |       383.7 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 1KB          |     1,533.7 ns |      5.76 ns |      5.39 ns |     1,532.3 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 1KB          |     1,852.5 ns |      9.36 ns |      8.30 ns |     1,855.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 1KB          |     2,025.3 ns |      4.91 ns |      4.35 ns |     2,025.1 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 1KB          |     2,092.6 ns |      3.89 ns |      3.64 ns |     2,092.2 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 1KB          |     2,188.8 ns |      9.11 ns |      8.52 ns |     2,186.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 1025B        |     1,531.5 ns |      5.01 ns |      4.18 ns |     1,532.6 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 1025B        |     1,821.3 ns |     11.07 ns |      9.81 ns |     1,817.9 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 1025B        |     2,029.0 ns |      6.94 ns |      6.15 ns |     2,028.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 1025B        |     2,093.4 ns |      5.61 ns |      5.24 ns |     2,093.3 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 1025B        |     2,194.4 ns |     10.59 ns |      9.91 ns |     2,194.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 8KB          |     9,979.0 ns |     40.81 ns |     34.08 ns |     9,968.1 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 8KB          |    11,811.9 ns |     48.08 ns |     44.98 ns |    11,788.5 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 8KB          |    13,504.4 ns |     27.00 ns |     23.94 ns |    13,500.3 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 8KB          |    13,912.2 ns |     21.81 ns |     18.21 ns |    13,911.6 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 8KB          |    15,009.4 ns |     26.76 ns |     22.34 ns |    15,006.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 128KB        |   158,213.7 ns |    589.99 ns |    551.87 ns |   158,432.1 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 128KB        |   184,887.7 ns |    783.07 ns |    694.17 ns |   184,696.6 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 128KB        |   214,319.0 ns |    464.20 ns |    411.50 ns |   214,335.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 128KB        |   220,677.8 ns |    399.07 ns |    373.29 ns |   220,648.8 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 128KB        |   239,010.1 ns |    753.88 ns |    629.52 ns |   238,802.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 128B         |       282.6 ns |      4.64 ns |      4.56 ns |       283.2 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 128B         |       350.6 ns |      1.10 ns |      1.03 ns |       350.3 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 128B         |       358.1 ns |      0.76 ns |      0.68 ns |       358.2 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 128B         |       365.2 ns |      2.48 ns |      2.20 ns |       364.8 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 128B         |       382.9 ns |      1.55 ns |      1.37 ns |       382.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 137B         |       529.6 ns |      2.09 ns |      1.96 ns |       529.7 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 137B         |       618.6 ns |      5.04 ns |      4.21 ns |       618.4 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 137B         |       661.9 ns |      3.89 ns |      3.64 ns |       661.6 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 137B         |       671.2 ns |      1.62 ns |      1.52 ns |       671.8 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 137B         |       690.9 ns |      0.67 ns |      0.56 ns |       691.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 1KB          |     1,721.8 ns |      9.38 ns |      8.77 ns |     1,719.0 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 1KB          |     2,033.6 ns |     11.72 ns |      9.78 ns |     2,037.6 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 1KB          |     2,280.7 ns |      5.85 ns |      5.47 ns |     2,279.7 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 1KB          |     2,339.9 ns |      4.71 ns |      4.41 ns |     2,340.3 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 1KB          |     2,483.8 ns |      4.24 ns |      3.76 ns |     2,483.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 1025B        |     1,706.5 ns |      9.04 ns |      8.46 ns |     1,706.8 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 1025B        |     2,037.8 ns |     14.32 ns |     12.69 ns |     2,033.7 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 1025B        |     2,286.2 ns |      6.99 ns |      6.20 ns |     2,286.5 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 1025B        |     2,350.4 ns |      5.81 ns |      5.43 ns |     2,350.9 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 1025B        |     2,487.7 ns |     10.65 ns |      9.96 ns |     2,485.5 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 8KB          |    12,453.6 ns |     60.66 ns |     56.74 ns |    12,457.2 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 8KB          |    14,517.6 ns |     46.44 ns |     41.16 ns |    14,510.1 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 8KB          |    16,748.3 ns |     39.53 ns |     35.04 ns |    16,750.5 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 8KB          |    17,185.4 ns |     34.69 ns |     28.97 ns |    17,192.0 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 8KB          |    18,574.8 ns |    130.98 ns |    122.52 ns |    18,516.2 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 128KB        |   194,095.2 ns |    724.59 ns |    642.33 ns |   194,103.6 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 128KB        |   226,334.7 ns |    791.43 ns |    660.88 ns |   226,193.6 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 128KB        |   263,161.1 ns |    671.88 ns |    595.61 ns |   263,278.7 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 128KB        |   271,375.1 ns |    647.90 ns |    505.84 ns |   271,479.8 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 128KB        |   292,977.4 ns |    631.44 ns |    492.99 ns |   293,043.4 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SM3 | BouncyCastle                            | 128B         |       810.2 ns |      2.35 ns |      2.09 ns |       809.8 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                             | **128B**         |       **953.9 ns** |      **2.38 ns** |      **2.11 ns** |       **953.8 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **137B**         |       **820.7 ns** |      **2.76 ns** |      **2.31 ns** |       **820.8 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **137B**         |       **946.7 ns** |      **1.59 ns** |      **1.41 ns** |       **946.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **1KB**          |     **4,388.3 ns** |     **27.55 ns** |     **25.77 ns** |     **4,376.9 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **1KB**          |     **5,180.0 ns** |     **16.81 ns** |     **15.73 ns** |     **5,172.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **1025B**        |     **4,384.4 ns** |     **12.54 ns** |     **10.47 ns** |     **4,382.3 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **1025B**        |     **5,180.3 ns** |     **15.82 ns** |     **14.80 ns** |     **5,172.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **8KB**          |    **33,028.2 ns** |    **174.48 ns** |    **154.67 ns** |    **33,027.3 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **8KB**          |    **39,002.1 ns** |    **109.90 ns** |    **102.80 ns** |    **39,002.2 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **128KB**        |   **530,869.3 ns** |  **1,991.79 ns** |  **1,863.12 ns** |   **530,086.3 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **128KB**        |   **617,303.4 ns** |  **1,308.87 ns** |  **1,092.97 ns** |   **617,010.4 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Streebog-256 | CryptoHives                    | 128B         |     2,476.9 ns |      3.76 ns |      3.33 ns |     2,476.2 ns |     112 B |
| **ComputeHash | Streebog-256 | OpenGost**                       | **128B**         |     **3,443.3 ns** |     **18.03 ns** |     **16.87 ns** |     **3,445.4 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 128B         |     4,275.3 ns |     18.67 ns |     17.46 ns |     4,276.2 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **137B**         |     **2,421.9 ns** |      **4.37 ns** |      **3.88 ns** |     **2,421.8 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **137B**         |     **3,950.8 ns** |     **17.25 ns** |     **15.30 ns** |     **3,947.8 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 137B         |     4,311.4 ns |     20.30 ns |     18.99 ns |     4,304.1 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **1KB**          |     **9,290.8 ns** |     **23.32 ns** |     **20.68 ns** |     **9,286.8 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **1KB**          |    **12,760.0 ns** |     **58.46 ns** |     **54.68 ns** |    **12,741.1 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 1KB          |    16,260.0 ns |    112.76 ns |    105.47 ns |    16,257.4 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **1025B**        |     **9,155.5 ns** |     **19.11 ns** |     **17.88 ns** |     **9,149.9 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **1025B**        |    **12,707.6 ns** |     **61.18 ns** |     **57.23 ns** |    **12,695.5 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 1025B        |    16,274.1 ns |     66.36 ns |     58.83 ns |    16,258.6 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **8KB**          |    **59,888.9 ns** |    **111.73 ns** |    **104.51 ns** |    **59,880.9 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **8KB**          |    **86,925.8 ns** |    **303.83 ns** |    **253.72 ns** |    **86,941.0 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 8KB          |   111,799.6 ns |    375.60 ns |    332.96 ns |   111,736.2 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **128KB**        |   **979,731.5 ns** |  **4,295.48 ns** |  **4,017.99 ns** |   **977,653.9 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **128KB**        | **1,360,224.0 ns** |  **8,170.77 ns** |  **7,642.95 ns** | **1,359,685.2 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 128KB        | 1,749,107.6 ns |  7,702.23 ns |  7,204.67 ns | 1,748,134.4 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **128B**         |     **2,459.9 ns** |      **5.79 ns** |      **5.42 ns** |     **2,461.1 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **128B**         |     **3,374.3 ns** |     **12.56 ns** |     **11.75 ns** |     **3,371.9 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 128B         |     4,286.4 ns |     22.86 ns |     21.39 ns |     4,280.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **137B**         |     **2,417.4 ns** |      **4.01 ns** |      **3.76 ns** |     **2,417.1 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **137B**         |     **3,357.8 ns** |     **12.26 ns** |     **10.87 ns** |     **3,357.3 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 137B         |     4,354.7 ns |     21.60 ns |     20.20 ns |     4,352.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **1KB**          |     **9,408.9 ns** |     **19.43 ns** |     **17.23 ns** |     **9,405.3 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **1KB**          |    **12,666.8 ns** |     **63.31 ns** |     **59.22 ns** |    **12,644.0 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 1KB          |    16,295.1 ns |    131.88 ns |    123.37 ns |    16,277.7 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **1025B**        |     **9,115.0 ns** |     **11.09 ns** |      **9.26 ns** |     **9,112.0 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **1025B**        |    **12,641.3 ns** |     **69.71 ns** |     **61.79 ns** |    **12,657.2 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 1025B        |    16,195.0 ns |     63.99 ns |     53.43 ns |    16,190.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **8KB**          |    **64,913.1 ns** |    **106.24 ns** |     **94.18 ns** |    **64,915.8 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **8KB**          |    **86,917.6 ns** |    **685.41 ns** |    **641.13 ns** |    **87,003.4 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 8KB          |   111,826.5 ns |    250.07 ns |    221.68 ns |   111,767.7 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **128KB**        |   **951,275.2 ns** |  **3,453.29 ns** |  **3,230.21 ns** |   **950,105.3 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **128KB**        | **1,357,663.3 ns** |  **5,531.83 ns** |  **4,903.82 ns** | **1,356,604.5 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 128KB        | 1,757,915.0 ns |  5,788.60 ns |  5,414.66 ns | 1,756,049.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 128B         |       181.9 ns |      0.42 ns |      0.35 ns |       182.0 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 128B         |       203.4 ns |      0.50 ns |      0.44 ns |       203.4 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 128B         |       214.8 ns |      0.71 ns |      0.55 ns |       214.7 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 137B         |       179.2 ns |      1.37 ns |      1.21 ns |       179.2 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 137B         |       200.4 ns |      0.54 ns |      0.51 ns |       200.4 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 137B         |       208.6 ns |      0.75 ns |      0.70 ns |       208.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 1KB          |       880.3 ns |      2.86 ns |      2.67 ns |       880.1 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 1KB          |     1,107.7 ns |      2.77 ns |      2.17 ns |     1,108.1 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 1KB          |     1,167.2 ns |      2.92 ns |      2.74 ns |     1,167.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 1025B        |       881.1 ns |      6.63 ns |      5.88 ns |       879.9 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 1025B        |     1,113.2 ns |      3.21 ns |      2.84 ns |     1,113.3 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 1025B        |     1,166.4 ns |      2.88 ns |      2.70 ns |     1,166.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 8KB          |     5,450.4 ns |     18.13 ns |     16.07 ns |     5,448.0 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 8KB          |     7,041.5 ns |     17.29 ns |     15.33 ns |     7,042.1 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 8KB          |     7,448.5 ns |     12.72 ns |     11.90 ns |     7,448.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 128KB        |    85,553.5 ns |    374.10 ns |    331.63 ns |    85,523.6 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 128KB        |   112,390.8 ns |    147.31 ns |    137.80 ns |   112,342.7 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 128KB        |   117,715.3 ns |    203.42 ns |    190.28 ns |   117,709.0 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 128B         |       185.7 ns |      0.65 ns |      0.55 ns |       185.7 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 128B         |       209.8 ns |      0.44 ns |      0.39 ns |       209.8 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 128B         |       217.5 ns |      0.43 ns |      0.38 ns |       217.5 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 137B         |       342.1 ns |      2.99 ns |      2.79 ns |       342.2 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 137B         |       387.3 ns |      0.84 ns |      0.74 ns |       387.1 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 137B         |       403.7 ns |      0.87 ns |      0.72 ns |       403.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 1KB          |       967.7 ns |      3.21 ns |      2.84 ns |       967.7 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 1KB          |     1,237.4 ns |      1.77 ns |      1.65 ns |     1,237.4 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 1KB          |     1,293.5 ns |      2.19 ns |      1.94 ns |     1,292.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 1025B        |       963.6 ns |      3.89 ns |      3.64 ns |       963.7 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 1025B        |     1,228.4 ns |      3.39 ns |      2.65 ns |     1,228.7 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 1025B        |     1,294.0 ns |      3.76 ns |      3.14 ns |     1,294.1 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 8KB          |     6,752.4 ns |     42.47 ns |     39.72 ns |     6,743.5 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 8KB          |     8,744.7 ns |     22.97 ns |     21.49 ns |     8,744.2 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 8KB          |     9,182.6 ns |     24.54 ns |     21.76 ns |     9,178.8 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 128KB        |   104,821.6 ns |    485.06 ns |    453.73 ns |   104,935.0 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 128KB        |   135,911.8 ns |    370.28 ns |    328.24 ns |   135,820.6 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 128KB        |   143,334.0 ns |    453.06 ns |    423.79 ns |   143,250.2 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **128B**         |     **1,368.8 ns** |      **8.95 ns** |      **8.37 ns** |     **1,366.7 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **128B**         |     **5,068.8 ns** |     **45.44 ns** |     **42.51 ns** |     **5,057.5 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **137B**         |     **1,385.8 ns** |      **3.46 ns** |      **2.89 ns** |     **1,386.1 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **137B**         |     **5,063.4 ns** |     **23.51 ns** |     **20.84 ns** |     **5,059.8 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **1KB**          |     **7,642.1 ns** |     **34.98 ns** |     **32.72 ns** |     **7,634.8 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **1KB**          |    **31,052.9 ns** |    **160.09 ns** |    **133.68 ns** |    **31,011.5 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **1025B**        |     **7,625.3 ns** |     **34.97 ns** |     **31.00 ns** |     **7,624.1 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **1025B**        |    **30,925.2 ns** |    **174.06 ns** |    **162.81 ns** |    **30,907.7 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **8KB**          |    **57,868.0 ns** |    **280.93 ns** |    **249.04 ns** |    **57,849.1 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **8KB**          |   **238,907.9 ns** |  **1,143.00 ns** |  **1,013.24 ns** |   **239,054.5 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **128KB**        |   **917,558.1 ns** |  **2,815.20 ns** |  **2,350.82 ns** |   **917,026.2 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **128KB**        | **3,804,573.5 ns** | **18,355.02 ns** | **17,169.30 ns** | **3,801,630.5 ns** |     **232 B** |
